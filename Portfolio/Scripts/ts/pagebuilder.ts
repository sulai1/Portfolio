import { TextContent, CodeContent, ExampleContent, IContent, SectionBuilder, ImageContent } from './sectionbuilder';


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

export const init = function(json:string){
    builder = SectionBuilder.fromJS(json);
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
                    el = el as ExampleContent;
                    col.append('<div class="col"><div id="' + id + '">' + el.text + "</div></div>");
                } else if (el instanceof CodeContent) {
                    el = el as CodeContent;
                    let outer = $('<div class="col"><pre class="pre-scrollable" ><code class="' + el.type + '"  id="' + id + '">' + toDisplayableCode(el.text) + '</code></pre></div>');
                    col.append(outer);
                }
                else if (el instanceof TextContent) {
                    el = el as TextContent;
                    col.append('<div class="col"><p id="' + id + '">' + el.text + '</p></div>');
                }
            } else {
                if (el instanceof ExampleContent) {
                    let text: ExampleContent = el;
                    c.html(text.text);
                } else if (el instanceof CodeContent) {
                    let text: CodeContent = el;
                    c.text(text.text);
                } else if (el instanceof TextContent) {
                    let text: TextContent = el;
                    c.text(text.text);
                }
            }
        }
    }
    contents(builder.content);
}