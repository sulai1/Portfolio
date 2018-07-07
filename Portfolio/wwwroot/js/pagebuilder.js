define(["require", "exports", "./sectionbuilder"], function (require, exports, sectionbuilder_1) {
    "use strict";
    exports.__esModule = true;
    var builder;
    var toDisplayableCode = function (string) {
        string = string.replace(/</g, '&lt;');
        string = string.replace(/>/g, '&gt;');
        return string;
    };
    exports.create = function (type) {
        switch (type) {
            case 'text':
                var a = new sectionbuilder_1.TextContent();
                a.text = "text";
                builder.content.push(a);
                break;
            case 'code':
                var b = new sectionbuilder_1.CodeContent();
                b.text = "<p>code</p>";
                builder.content.push(b);
                break;
            case 'sample':
                var c = new sectionbuilder_1.ExampleContent();
                c.text = "<p>code example</p>";
                builder.content.push(c);
                break;
            case 'img':
                var d = new sectionbuilder_1.ImageContent();
                d.path = "file://D:/Pictures/Texturen/bee.jpg";
                d.alt = "missing image!";
                builder.content.push(d);
                break;
        }
    };
    exports.init = function (json) {
        builder = sectionbuilder_1.SectionBuilder.fromJS(json);
    };
    exports.draw = function () {
        var contents = function (content) {
            var col = $("#col");
            if (col.length == 0)
                col = $('<div class="col" id="col"></div>');
            $('#container').append(col);
            for (var i = 0; i < content.length; i++) {
                var el = content[i];
                var id = "Content" + i;
                var c = $("#" + id);
                if (c.length == 0) {
                    if (el instanceof sectionbuilder_1.ExampleContent) {
                        el = el;
                        col.append('<div class="col"><div id="' + id + '">' + el.text + "</div></div>");
                    }
                    else if (el instanceof sectionbuilder_1.CodeContent) {
                        el = el;
                        var outer = $('<div class="col"><pre class="pre-scrollable" ><code class="' + el.type + '"  id="' + id + '">' + toDisplayableCode(el.text) + '</code></pre></div>');
                        col.append(outer);
                    }
                    else if (el instanceof sectionbuilder_1.TextContent) {
                        el = el;
                        col.append('<div class="col"><p id="' + id + '">' + el.text + '</p></div>');
                    }
                }
                else {
                    if (el instanceof sectionbuilder_1.ExampleContent) {
                        var text = el;
                        c.html(text.text);
                    }
                    else if (el instanceof sectionbuilder_1.CodeContent) {
                        var text = el;
                        c.text(text.text);
                    }
                    else if (el instanceof sectionbuilder_1.TextContent) {
                        var text = el;
                        c.text(text.text);
                    }
                }
            }
        };
        contents(builder.content);
    };
});
//# sourceMappingURL=pagebuilder.js.map