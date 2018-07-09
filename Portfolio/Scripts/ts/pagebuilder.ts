import { TextContent, CodeContent, ExampleContent, IContent, SectionBuilder, ImageContent } from './sectionbuilder';
import { URL } from 'url';
import { error } from 'util';
import { win32 } from 'path';
import { read } from 'fs';


var textContentTemplate: string;
var codeContentTemplate: string;
var sampleContentTemplate: string;
var imgContentTemplate: string;
var controlTemplate: string;

var builder: SectionBuilder;

function toDisplayableCode(string: string): string {
    string = string.replace(/</g, '&lt;');
    string = string.replace(/>/g, '&gt;');
    return string;
}

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
}
/**
 * Create a new Sectionbuilder from the json string.
 * Load all of the content and control templates from the document
 * @param json The json string that is used to create the Sectionbuilder
 */
export function init(json: string) {
    builder = SectionBuilder.fromJS(json);
    let tmp1 = new TextContent();
    textContentTemplate = $("." + (<any>tmp1).constructor.name)[0].innerHTML;
    let tmp2 = new CodeContent();
    codeContentTemplate = $("." + (<any>tmp2).constructor.name)[0].innerHTML;
    let tmp3 = new ExampleContent();
    sampleContentTemplate = $("." + (<any>tmp3).constructor.name)[0].innerHTML;
    let tmp4 = new ImageContent();
    imgContentTemplate = $("." + (<any>tmp4).constructor.name)[0].innerHTML;
    controlTemplate = $(".content-control")[0].innerHTML;
}
export function save(){
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
    var contents = function (content) {
        var col = $("#col")
        if (col.length == 0)
            col = $('<div class="col" id="col"></div>');
        $('#container').append(col);
        for (var i = 0; i < content.length; i++) {
            var el = content[i];
            var id = "Content" + i;
            var c = $("#" + id);
            if (c.length == 0) {
                if (el instanceof ExampleContent) {
                    let clone = initContent(i, sampleContentTemplate, col);
                    sampleContent(clone, el as ExampleContent, id);
                } else if (el instanceof CodeContent) {
                    let clone = initContent(i, codeContentTemplate, col);
                    codeContent(clone, el as CodeContent, id);
                }
                else if (el instanceof TextContent) {
                    let clone = initContent(i, textContentTemplate, col);
                    textContent(clone, el as TextContent, id);
                }
                else if (el instanceof ImageContent) {
                    let clone = initContent(i, imgContentTemplate, col);
                    imgContent(clone, el as ImageContent, id);
                }
            } else {
                if (el instanceof ExampleContent) {
                    sampleContent(c, el as CodeContent, id);
                }
                else if (el instanceof CodeContent) {
                    codeContent(c, el as CodeContent, id);
                }
                else if (el instanceof TextContent) {
                    textContent(c, el as CodeContent, id);
                }
                else if (el instanceof ImageContent) {
                    imgContent(c, el as ImageContent, id);
                }
            }
        }
    }
    contents(builder.content);
}

function indexOf(el: JQuery<HTMLElement>): number {
    return parseInt(el.attr("id").match(/\d*$/)[0]);
}

/**
 * Create new content and append it to the content area.
 * @param id The id is used to find the content in the document
 * @param template The template is used to create the element
 * @param area The content area where the new element is added to 
 */
function initContent(id: number, template: string, area: JQuery<HTMLElement>) {
    let content = $(template);
    let control = $(controlTemplate);

    content.attr("id", "Content" + id);

    // hide edit
    let edit = content.find(".edit");
    edit.hide(0);
    control.find(".edit-btn").click(function () {
        edit.toggle();
    });


    // swap up and down
    control.find(".up").click(function () {
        up(content);
    });
    control.find(".down").click(function () {
        down(content);
    });

    // add the content
    content.append(control);
    area.append(content);
    return content;
}

function codeContent(content: JQuery<HTMLElement>, el: CodeContent, id: string): JQuery<HTMLElement> {
    let code = content.find('code').first();
    code.attr("class", el.type);
    code.html(toDisplayableCode(el.text));

    // bind text and type
    let text = content.find(".text-edit");
    text.text(el.text);

    let type = content.find(".type-edit");
    type.val(el.type);

    let save = content.find(".save-btn");
    save.click(function () {
        el.text = text.val().toString();
        el.type = type.val().toString();
        draw();
    });
    return content;
}

function textContent(content: JQuery<HTMLElement>, el: TextContent, id: string): JQuery<HTMLElement> {
    content.find('p').first().text(el.text).text(el.text);
    // bind edit
    let edit = content.find(".text-edit");
    let save = content.find(".save-btn");
    edit.val(el.text);
    save.click(function () {
        el.text = edit.val().toString();
        draw();
    });
    return content;
}
function sampleContent(content: JQuery<HTMLElement>, el: ExampleContent, id: string): JQuery<HTMLElement> {
    content.find('.sample').first().html(el.text);
    // bind edit
    let text = content.find(".text-edit");
    text.val(el.text);
    let save = content.find(".save-btn");
    save.click(function () {
        el.text = text.val().toString();
        draw();
    });
    return content;
}
function imgContent(content: JQuery<HTMLElement>, el: ImageContent, id: string): JQuery<HTMLElement> {
    let img = content.find('img').first();
    img.attr("src", el.path);
    img.attr("alt", el.alt);
    // bind edit
    let alt = content.find(".alt-edit");
    alt.val(el.alt);

    let src = content.find(".src-edit");

    let save = content.find(".save-btn");
    save.click(function () {
        el.alt = alt.val().toString();
        var file = src.prop('files')[0];
        uploadImage(file, el);
    });

    return content;

    function uploadImage(file: any, c: ImageContent) {
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
            request.open('POST', window.location.href + "/AddImage");
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
