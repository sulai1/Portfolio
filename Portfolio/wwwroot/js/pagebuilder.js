define(["require", "exports", "./sectionbuilder"], function (require, exports, sectionbuilder_1) {
    "use strict";
    exports.__esModule = true;
    var textContentTemplate;
    var codeContentTemplate;
    var sampleContentTemplate;
    var imgContentTemplate;
    var controlTemplate;
    var builder;
    function toDisplayableCode(string) {
        string = string.replace(/</g, '&lt;');
        string = string.replace(/>/g, '&gt;');
        return string;
    }
    function create(type) {
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
    }
    exports.create = create;
    /**
     * Create a new Sectionbuilder from the json string.
     * Load all of the content and control templates from the document
     * @param json The json string that is used to create the Sectionbuilder
     */
    function init(json) {
        builder = sectionbuilder_1.SectionBuilder.fromJS(json);
        var tmp1 = new sectionbuilder_1.TextContent();
        textContentTemplate = $("." + tmp1.constructor.name)[0].innerHTML;
        var tmp2 = new sectionbuilder_1.CodeContent();
        codeContentTemplate = $("." + tmp2.constructor.name)[0].innerHTML;
        var tmp3 = new sectionbuilder_1.ExampleContent();
        sampleContentTemplate = $("." + tmp3.constructor.name)[0].innerHTML;
        var tmp4 = new sectionbuilder_1.ImageContent();
        imgContentTemplate = $("." + tmp4.constructor.name)[0].innerHTML;
        controlTemplate = $(".content-control")[0].innerHTML;
    }
    exports.init = init;
    function save() {
        $('#json').val(JSON.stringify(builder.toJSON()));
    }
    exports.save = save;
    /**
     * Swap the elements position with its upper neighbour
     * @param el the element to swap
     */
    function up(el) {
        var index = indexOf(el);
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
    /**
     * Swap the elements position with its bottom neighbour
     * @param el the element to swap
     */
    function down(el) {
        var index = indexOf(el);
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
    /**
     * draw all content from the section builder,
     * creating new Content if not allready displayed or reusing old elements.
     * */
    function draw() {
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
    }
    exports.draw = draw;
    function indexOf(el) {
        return parseInt(el.attr("id").match(/\d*$/)[0]);
    }
    /**
     * Create new content and append it to the content area.
     * @param id The id is used to find the content in the document
     * @param template The template is used to create the element
     * @param area The content area where the new element is added to
     */
    function initContent(id, template, area) {
        var content = $(template);
        var control = $(controlTemplate);
        content.attr("id", "Content" + id);
        // hide edit
        var edit = content.find(".edit");
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
    function codeContent(content, el, id) {
        var code = content.find('code').first();
        code.attr("class", el.type);
        code.html(toDisplayableCode(el.text));
        // bind text and type
        var text = content.find(".text-edit");
        text.text(el.text);
        var type = content.find(".type-edit");
        type.val(el.type);
        var save = content.find(".save-btn");
        save.click(function () {
            el.text = text.val().toString();
            el.type = type.val().toString();
            draw();
        });
        return content;
    }
    function textContent(content, el, id) {
        content.find('p').first().text(el.text).text(el.text);
        // bind edit
        var edit = content.find(".text-edit");
        var save = content.find(".save-btn");
        edit.val(el.text);
        save.click(function () {
            el.text = edit.val().toString();
            draw();
        });
        return content;
    }
    function sampleContent(content, el, id) {
        content.find('.sample').first().html(el.text);
        // bind edit
        var text = content.find(".text-edit");
        text.val(el.text);
        var save = content.find(".save-btn");
        save.click(function () {
            el.text = text.val().toString();
            draw();
        });
        return content;
    }
    function imgContent(content, el, id) {
        var img = content.find('img').first();
        img.attr("src", el.path);
        img.attr("alt", el.alt);
        // bind edit
        var alt = content.find(".alt-edit");
        alt.val(el.alt);
        var src = content.find(".src-edit");
        var save = content.find(".save-btn");
        save.click(function () {
            el.alt = alt.val().toString();
            var file = src.prop('files')[0];
            uploadImage(file, el);
        });
        return content;
        function uploadImage(file, c) {
            var reader = new FileReader();
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
                var request = new XMLHttpRequest();
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
});
//# sourceMappingURL=pagebuilder.js.map