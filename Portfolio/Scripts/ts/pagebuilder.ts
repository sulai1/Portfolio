import { TextContent, CodeContent, ExampleContent, IContent, SectionBuilder, ImageContent, IImageContent } from './sectionbuilder';
import { URL } from 'url';
import { error } from 'util';
import { win32 } from 'path';
import { read } from 'fs';

var textBuilder: TextBuilder;
var codeBuilder: CodeBuilder;
var sampleBuilder: ExampleBuilder;
var imgBuilder: ImageBuilder;

var controlTemplate: string;

var builder: SectionBuilder;

export function create(type: string) {
    switch (type) {
        case 'text':
            let a = new TextContent();
            a.text = "text";
            builder.content.push(a);
            break;
        case 'code':
            let b = new CodeContent();
            b.text = "<p>code</p>";
            builder.content.push(b);
            break;
        case 'sample':
            let c = new ExampleContent();
            c.text = "<p>code example</p>";
            builder.content.push(c);
            break;
        case 'img':
            let d = new ImageContent();
            d.path = "file://D:/Pictures/Texturen/bee.jpg";
            d.alt = "missing image!"
            builder.content.push(d);
            break;
    }
    draw();
}
/**
 * Create a new Sectionbuilder from the json string.
 * Load all of the content and control templates from the document
 * @param json The json string that is used to create the Sectionbuilder
 */
export function init(json: string, edit = true) {
    const ed = "-edit";
    builder = SectionBuilder.fromJS(json);
    let tmp1 = new TextContent();
    textBuilder = new TextBuilder($("#" + (<any>tmp1).constructor.name)[0].innerHTML,
        $("#" + (<any>tmp1).constructor.name + ed)[0].innerHTML, edit);
    let tmp2 = new CodeContent();
    codeBuilder = new CodeBuilder($("#" + (<any>tmp2).constructor.name)[0].innerHTML,
        $("#" + (<any>tmp2).constructor.name + ed)[0].innerHTML, edit);
    let tmp3 = new ExampleContent();
    sampleBuilder = new ExampleBuilder($("#" + (<any>tmp3).constructor.name)[0].innerHTML,
        $("#" + (<any>tmp3).constructor.name + ed)[0].innerHTML, edit);
    let tmp4 = new ImageContent();
    imgBuilder = new ImageBuilder($("#" + (<any>tmp4).constructor.name)[0].innerHTML,
        $("#" + (<any>tmp4).constructor.name + ed)[0].innerHTML, edit);
    controlTemplate = $(".content-control")[0].innerHTML;
}
export function save() {
    $('#json').val(JSON.stringify(builder.toJSON()));
}

/**
 * Swap the elements position with its upper neighbour
 * @param el the element to swap
 */
export function up(el: JQuery<HTMLElement>) {
    var index = indexOf(el)
    if (index > 0 && index < builder.content.length) {

        let a = $("#Content" + index);
        let b = $("#Content" + (index - 1));
        a.after(b);
        a.attr("id", "Content" + (index - 1));
        b.attr("id", "Content" + index);
        let contentTmp = builder.content[index];
        builder.content[index] = builder.content[index - 1];
        builder.content[index - 1] = contentTmp;
    }
}

/**
 * Swap the elements position with its bottom neighbour
 * @param el the element to swap
 */
export function down(el: JQuery<HTMLElement>) {
    var index = indexOf(el)
    if (index >= 0 && index < builder.content.length - 1) {
        let a = $("#Content" + index);
        let b = $("#Content" + (index + 1));
        a.before(b);
        a.attr("id", "Content" + (index + 1));
        b.attr("id", "Content" + index);
        let contentTmp = builder.content[index];
        builder.content[index] = builder.content[index + 1];
        builder.content[index + 1] = contentTmp;
    }
}

/**
 * draw all content from the section builder,
 * creating new Content if not allready displayed or reusing old elements.
 * */
export function draw() {
    var col = $('#container');
    for (var i = 0; i < builder.content.length; i++) {
        var el = builder.content[i];
        var id = "Content" + i;
        var c = $("#" + id);
        // check if element was allready created
        if (c.length == 0) {
            if (el instanceof ExampleContent) {
                c = sampleBuilder.init(i, el, col);
            }
            else if (el instanceof CodeContent) {
                c = codeBuilder.init(i, el, col);
            }
            else if (el instanceof TextContent) {
                c = textBuilder.init(i, el, col);
            }
            else if (el instanceof ImageContent) {
                c = imgBuilder.init(i, el, col);
            }
        }
        else {
            if (el instanceof ExampleContent) {
                sampleBuilder.setContent(c, el);
            }
            else if (el instanceof CodeContent) {
                codeBuilder.setContent(c, el);
            }
            else if (el instanceof TextContent) {
                textBuilder.setContent(c, el);
            }
            else if (el instanceof ImageContent) {
                imgBuilder.setContent(c, el);
            }
        }
    }
}

function toDisplayableCode(string: string): string {
    string = string.replace(/</g, '&lt;');
    string = string.replace(/>/g, '&gt;');
    return string;
}

function indexOf(el: JQuery<HTMLElement>): number {
    return parseInt(el.attr("id").match(/\d*$/)[0]);
}
//#region ContentBuilding
abstract class IContentBuilder<T extends IContent>{

    private edit: boolean;
    private editTemplate: string;
    private template: string;

    private static readonly content_col = ".content-col";
    /**
     * Create new contentbuilder that uses the given templates.
     * @param template The template is used to create the element
     * @param controlTemplate The template is used to create and bind the control elements
     */
    public constructor(template: string, controlTemplate: string, edit = false) {
        this.template = template;
        this.editTemplate = controlTemplate;
        this.edit = edit;
    }

    /**
     * Initialize a new content and add it to the html document
     * @param index the index of the element. Used for re/ordering
     * @param content the IContent element to store the data
     * @param area the area that holds the element.
     * @param editable add and bind edit template if the content is editable
     */
    public init(index: number, content: T, area: JQuery<HTMLElement>): JQuery<HTMLElement> {
        let element = $(this.template);
        element.attr("id", "Content" + index);
        //only add edits when required
        if (this.edit) {
            let control = $(controlTemplate);
            let col = element.find(IContentBuilder.content_col);
            col.append(this.editTemplate);
            element.append(control);

            // hide edit
            let edit = element.find(".edit");
            edit.hide(0);
            control.find(".edit-btn").click(function () {
                edit.toggle();
            });
            // swap up and down
            control.find(".up").click(function () {
                up(element);
            });
            control.find(".down").click(function () {
                down(element);
            });
            control.find(".delete").click(function () {
                if (confirm("Delete Element?")) {
                    element.remove();
                    for (var i = index + 1; i < builder.content.length; i++) {
                        $("Content" + i).attr("id", "Content" + (i - 1));
                    }
                    builder.content.splice(index, 1);
                }
            });
            this.bindEdit(element, content);
        }


        // add the content
        area.append(element);
        this.setContent(element, content);
        return element;
    }
    public bindEdit(element: JQuery<HTMLElement>, content: T): JQuery<HTMLElement> {
        let save = element.find(".save-btn");
        save.click(() => {
            this.save(element, content);
            draw();
        });
        this.setEdit(element, content);
        return element;
    }
    /**
     * Set the html display elements using the supplied contents
     * @param element the element containing the display elements
     * @param content the content to use
     */
    public abstract setContent(element: JQuery<HTMLElement>, content: T): JQuery<HTMLElement>;
    /**
     * Initialize the edits using the supplied contents
     * @param element the element containing the edit elements
     * @param content the content to use
     */
    public abstract setEdit(element: JQuery<HTMLElement>, content: T);
    /**
     * Save the edited values to the content
     * @param element the element containing the edits
     * @param content the content to update
     */
    public abstract save(element: JQuery<HTMLElement>, content: T);
}
class TextBuilder extends IContentBuilder<TextContent> {
    public setEdit(element: JQuery<HTMLElement>, content: TextContent) {
        let edit = element.find(".text-edit");
        edit.text(content.text);
    }
    public setContent(element: JQuery<HTMLElement>, content: TextContent): JQuery<HTMLElement> {
        element.find('p').first().text(content.text).text(content.text);
        return element;
    }
    public save(element: JQuery<HTMLElement>, content: TextContent) {
        // bind edit
        let edit = element.find(".text-edit");
        let save = element.find(".save-btn");
        content.text = edit.val().toString();
    }
}
class CodeBuilder extends IContentBuilder<CodeContent> {

    public setEdit(element: JQuery<HTMLElement>, content: CodeContent) {
        let text = element.find(".text-edit");
        text.text(content.text)
    }
    public setContent(element: JQuery<HTMLElement>, content: CodeContent): JQuery<HTMLElement> {
        let code = element.find('code').first();
        code.attr("class", content.type);
        code.html(toDisplayableCode(content.text));
        return element;
    }
    public

    public save(element: JQuery<HTMLElement>, content: CodeContent) {
        let text = element.find(".text-edit");
        let type = element.find(".type-edit");
        content.text = text.val().toString();
        content.type = type.val().toString();
    }
}
class ExampleBuilder extends IContentBuilder<ExampleContent> {
    public setEdit(element: JQuery<HTMLElement>, content: ExampleContent) {
        let edit = element.find(".text-edit");
        edit.val(content.text);
    }
    public setContent(element: JQuery<HTMLElement>, content: ExampleContent): JQuery<HTMLElement> {
        let sample = element.find(".sample");
        sample.html(content.text);
        return element;
    }
    public save(element: JQuery<HTMLElement>, content: ExampleContent) {
        content.text = element.find('.text-edit').val().toString();
    }
}
class ImageBuilder extends IContentBuilder<ImageContent> {
    public setEdit(element: JQuery<HTMLElement>, content: ImageContent) {
        let alt = element.find(".alt-edit");
        alt.text(content.alt);
        let src = element.find(".src-edit");
        src.text(content.path);
    }
    public setContent(element: JQuery<HTMLElement>, content: IImageContent): JQuery<HTMLElement> {
        let img = element.find('img').first();
        img.attr("src", content.path);
        img.attr("alt", content.alt);
        return element;
    }
    public save(element: JQuery<HTMLElement>, content: ImageContent) {
        let img = element.find('img').first();
        // bind edit
        let alt = element.find(".alt-edit");
        alt.val(content.alt);

        let src = element.find(".src-edit");

        let save = element.find(".save-btn");
        content.alt = alt.val().toString();
        var file = src.prop('files')[0];
        this.uploadImage(file, content);

    }
    private uploadImage(file: any, c: ImageContent) {
        let reader = new FileReader();
        //$.ajax({
        //    url: window.location.href + "/AddImage",
        //    contentType: "text/plain",
        //    data: "test",
        //    type: "post",
        //    dataType: "text",
        //    success: function (data) {
        //        alert(data);
        //    },
        //    error: function (err) {
        //        alert(err);
        //    }
        //});
        reader.onload = function (e) {
            let request = new XMLHttpRequest();
            // send response as text
            request.responseType = "text";
            // send a post to add the image
            var href = window.location.href;
            var url = href.substr(0, href.lastIndexOf("/"));
            request.open('POST', url + "/AddImage");
            // display the response when it comes in
            request.onload = function () {
                alert(request.response);
                c.path = request.response;
                draw();
            };
            //send the request
            request.send('name:test.png;' + reader.result);
        };
        reader.readAsDataURL(file);
    }
}
//#endregion