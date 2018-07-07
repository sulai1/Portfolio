define(["require", "exports", "./sectionbuilder"], function (require, exports, sectionbuilder_1) {
    "use strict";
    exports.__esModule = true;
    var textContentTemplate;
    var codeContentTemplate;
    var sampleContentTemplate;
    var imgContentTemplate;
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
        var tmp1 = new sectionbuilder_1.TextContent();
        textContentTemplate = $("." + tmp1.constructor.name)[0].innerHTML;
        var tmp2 = new sectionbuilder_1.CodeContent();
        codeContentTemplate = $("." + tmp2.constructor.name)[0].innerHTML;
        var tmp3 = new sectionbuilder_1.ExampleContent();
        sampleContentTemplate = $("." + tmp3.constructor.name)[0].innerHTML;
        var tmp4 = new sectionbuilder_1.ImageContent();
        imgContentTemplate = $("." + tmp4.constructor.name)[0].innerHTML;
    };
    function up(el) {
        var index = parseInt(el.attr("id").match(/\d*$/)[0]);
        if (index > 0 && index < builder.content.length) {
            var a = $("#Content" + index);
            var b = $("#Content" + (index - 1));
            a.after(b);
            a.attr("id", "Content" + (index - 1));
            b.attr("id", "Content" + index);
            var contentTmp = builder.content[index];
            builder.content[index] = builder.content[index - 1];
            builder.content[index - 1] = contentTmp;
        }
    }
    exports.up = up;
    function down(el) {
        var index = parseInt(el.attr("id").match(/\d*$/)[0]);
        if (index >= 0 && index < builder.content.length - 1) {
            var a = $("#Content" + index);
            var b = $("#Content" + (index + 1));
            a.before(b);
            a.attr("id", "Content" + (index + 1));
            b.attr("id", "Content" + index);
            var contentTmp = builder.content[index];
            builder.content[index] = builder.content[index + 1];
            builder.content[index + 1] = contentTmp;
        }
    }
    exports.down = down;
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
                        var clone = initContent(i, sampleContentTemplate, col);
                        sampleContent(clone, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.CodeContent) {
                        var clone = initContent(i, codeContentTemplate, col);
                        codeContent(clone, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.TextContent) {
                        var clone = initContent(i, textContentTemplate, col);
                        textContent(clone, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.ImageContent) {
                        var clone = initContent(i, imgContentTemplate, col);
                        imgContent(clone, el, id);
                    }
                }
                else {
                    if (el instanceof sectionbuilder_1.ExampleContent) {
                        sampleContent(c, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.CodeContent) {
                        codeContent(c, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.TextContent) {
                        textContent(c, el, id);
                    }
                    else if (el instanceof sectionbuilder_1.ImageContent) {
                        imgContent(c, el, id);
                    }
                }
            }
        };
        contents(builder.content);
    };
    function initContent(id, template, col) {
        var clone = $(template);
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
    function codeContent(template, el, id) {
        var code = template.find('code').first();
        code.attr("class", el.type);
        code.html(toDisplayableCode(el.text));
        return template;
    }
    function textContent(template, el, id) {
        template.find('p').first().text(el.text).text(el.text);
        return template;
    }
    function sampleContent(template, el, id) {
        template.find('div').first().html(el.text);
        return template;
    }
    function imgContent(template, el, id) {
        var img = template.find('img').first();
        img.attr("src", el.path);
        img.attr("alt", el.alt);
        return template;
    }
    imgContent;
});
//# sourceMappingURL=pagebuilder.js.map