import { TextContent, CodeContent, ExampleContent, IContent, SectionBuilder, ImageContent } from './sectionbuilder';


var textContentTemplate: string;
var codeContentTemplate: string;
var sampleContentTemplate: string;
var imgContentTemplate: string;

var builder: SectionBuilder;

var toDisplayableCode = function (string: string) {
    string = string.replace(/</g, '&lt;');
    string = string.replace(/>/g, '&gt;');
    return string;
}

export const create = function (type: string) {
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

export const init = function (json: string) {
    builder = SectionBuilder.fromJS(json);
    let tmp1 = new TextContent();
    textContentTemplate = $("." + (<any>tmp1).constructor.name)[0].innerHTML;
    let tmp2 = new CodeContent();
    codeContentTemplate = $("." + (<any>tmp2).constructor.name)[0].innerHTML;
    let tmp3 = new ExampleContent();
    sampleContentTemplate = $("." + (<any>tmp3).constructor.name)[0].innerHTML;
    let tmp4 = new ImageContent();
    imgContentTemplate = $("." + (<any>tmp4).constructor.name)[0].innerHTML;
}

export function up(el: JQuery<HTMLElement>) {
    var index = parseInt(el.attr("id").match(/\d*$/)[0])
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
export function down(el: JQuery<HTMLElement>) {
    var index = parseInt(el.attr("id").match(/\d*$/)[0])
    if (index >= 0 && index < builder.content.length-1) {
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

export const draw = function () {
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

function initContent(id: number, template: string, col: JQuery<HTMLElement>) {
    let clone = $(template);
    clone.attr("id", "Content" + id);
    clone.find("#up").click(function () {
        up(clone);
    });
    clone.find("#down").click(function () {
        down(clone);
    });
    col.append(clone);
    return clone;
}

function codeContent(template: JQuery<HTMLElement>, el: CodeContent, id: string) {
    let code = template.find('code').first();
    code.attr("class", el.type);
    code.html(toDisplayableCode(el.text));
    return template;
}

function textContent(template: JQuery<HTMLElement>, el: TextContent, id: string) {
    template.find('p').first().text(el.text).text(el.text);
    return template;
}
function sampleContent(template: JQuery<HTMLElement>, el: ExampleContent, id: string) {
    template.find('div').first().html(el.text);
    return template;
}
function imgContent(template: JQuery<HTMLElement>, el: ImageContent, id: string) {
    let img = template.find('img').first();
    img.attr("src", el.path);
    img.attr("alt", el.alt);
    return template;
}
imgContent