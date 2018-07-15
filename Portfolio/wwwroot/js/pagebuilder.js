var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
define(["require", "exports", "./sectionbuilder"], function (require, exports, sectionbuilder_1) {
    "use strict";
    exports.__esModule = true;
    var textBuilder;
    var codeBuilder;
    var sampleBuilder;
    var imgBuilder;
    var controlTemplate;
    var builder;
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
        draw();
    }
    exports.create = create;
    /**
     * Create a new Sectionbuilder from the json string.
     * Load all of the content and control templates from the document
     * @param json The json string that is used to create the Sectionbuilder
     */
    function init(json, edit) {
        if (edit === void 0) { edit = true; }
        var ed = "-edit";
        builder = sectionbuilder_1.SectionBuilder.fromJS(json);
        var tmp1 = new sectionbuilder_1.TextContent();
        textBuilder = new TextBuilder($("#" + tmp1.constructor.name)[0].innerHTML, $("#" + tmp1.constructor.name + ed)[0].innerHTML, edit);
        var tmp2 = new sectionbuilder_1.CodeContent();
        codeBuilder = new CodeBuilder($("#" + tmp2.constructor.name)[0].innerHTML, $("#" + tmp2.constructor.name + ed)[0].innerHTML, edit);
        var tmp3 = new sectionbuilder_1.ExampleContent();
        sampleBuilder = new ExampleBuilder($("#" + tmp3.constructor.name)[0].innerHTML, $("#" + tmp3.constructor.name + ed)[0].innerHTML, edit);
        var tmp4 = new sectionbuilder_1.ImageContent();
        imgBuilder = new ImageBuilder($("#" + tmp4.constructor.name)[0].innerHTML, $("#" + tmp4.constructor.name + ed)[0].innerHTML, edit);
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
        var col = $('#container');
        for (var i = 0; i < builder.content.length; i++) {
            var el = builder.content[i];
            var id = "Content" + i;
            var c = $("#" + id);
            // check if element was allready created
            if (c.length == 0) {
                if (el instanceof sectionbuilder_1.ExampleContent) {
                    c = sampleBuilder.init(i, el, col);
                }
                else if (el instanceof sectionbuilder_1.CodeContent) {
                    c = codeBuilder.init(i, el, col);
                }
                else if (el instanceof sectionbuilder_1.TextContent) {
                    c = textBuilder.init(i, el, col);
                }
                else if (el instanceof sectionbuilder_1.ImageContent) {
                    c = imgBuilder.init(i, el, col);
                }
            }
            else {
                if (el instanceof sectionbuilder_1.ExampleContent) {
                    sampleBuilder.setContent(c, el);
                }
                else if (el instanceof sectionbuilder_1.CodeContent) {
                    codeBuilder.setContent(c, el);
                }
                else if (el instanceof sectionbuilder_1.TextContent) {
                    textBuilder.setContent(c, el);
                }
                else if (el instanceof sectionbuilder_1.ImageContent) {
                    imgBuilder.setContent(c, el);
                }
            }
        }
    }
    exports.draw = draw;
    function toDisplayableCode(string) {
        string = string.replace(/</g, '&lt;');
        string = string.replace(/>/g, '&gt;');
        return string;
    }
    function indexOf(el) {
        return parseInt(el.attr("id").match(/\d*$/)[0]);
    }
    //#region ContentBuilding
    var IContentBuilder = /** @class */ (function () {
        /**
         * Create new contentbuilder that uses the given templates.
         * @param template The template is used to create the element
         * @param controlTemplate The template is used to create and bind the control elements
         */
        function IContentBuilder(template, controlTemplate, edit) {
            if (edit === void 0) { edit = false; }
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
        IContentBuilder.prototype.init = function (index, content, area) {
            var element = $(this.template);
            element.attr("id", "Content" + index);
            //only add edits when required
            if (this.edit) {
                var control = $(controlTemplate);
                var col = element.find(IContentBuilder.content_col);
                col.append(this.editTemplate);
                element.append(control);
                // hide edit
                var edit_1 = element.find(".edit");
                edit_1.hide(0);
                control.find(".edit-btn").click(function () {
                    edit_1.toggle();
                });
                // swap up and down
                control.find(".up").click(function () {
                    up(element);
                });
                control.find(".down").click(function () {
                    down(element);
                });
                control.find(".delete").click(function () {
                    remove(element);
                });
                this.bindEdit(element, content);
            }
            // add the content
            area.append(element);
            this.setContent(element, content);
            return element;
        };
        IContentBuilder.prototype.bindEdit = function (element, content) {
            var _this = this;
            var save = element.find(".save-btn");
            save.click(function () {
                _this.save(element, content);
                draw();
            });
            this.setEdit(element, content);
            return element;
        };
        IContentBuilder.content_col = ".content-col";
        return IContentBuilder;
    }());
    var TextBuilder = /** @class */ (function (_super) {
        __extends(TextBuilder, _super);
        function TextBuilder() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        TextBuilder.prototype.setEdit = function (element, content) {
            var edit = element.find(".text-edit");
            edit.text(content.text);
        };
        TextBuilder.prototype.setContent = function (element, content) {
            element.find('p').first().text(content.text).text(content.text);
            return element;
        };
        TextBuilder.prototype.save = function (element, content) {
            // bind edit
            var edit = element.find(".text-edit");
            var save = element.find(".save-btn");
            content.text = edit.val().toString();
        };
        return TextBuilder;
    }(IContentBuilder));
    var CodeBuilder = /** @class */ (function (_super) {
        __extends(CodeBuilder, _super);
        function CodeBuilder() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        CodeBuilder.prototype.setEdit = function (element, content) {
            var text = element.find(".text-edit");
            text.text(content.text);
        };
        CodeBuilder.prototype.setContent = function (element, content) {
            var code = element.find('code').first();
            code.attr("class", content.type);
            code.html(toDisplayableCode(content.text));
            return element;
        };
        CodeBuilder.prototype.save = function (element, content) {
            var text = element.find(".text-edit");
            var type = element.find(".type-edit");
            content.text = text.val().toString();
            content.type = type.val().toString();
        };
        return CodeBuilder;
    }(IContentBuilder));
    var ExampleBuilder = /** @class */ (function (_super) {
        __extends(ExampleBuilder, _super);
        function ExampleBuilder() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        ExampleBuilder.prototype.setEdit = function (element, content) {
            var edit = element.find(".text-edit");
            edit.val(content.text);
        };
        ExampleBuilder.prototype.setContent = function (element, content) {
            var sample = element.find(".sample");
            sample.html(content.text);
            return element;
        };
        ExampleBuilder.prototype.save = function (element, content) {
            content.text = element.find('.text-edit').val().toString();
        };
        return ExampleBuilder;
    }(IContentBuilder));
    var ImageBuilder = /** @class */ (function (_super) {
        __extends(ImageBuilder, _super);
        function ImageBuilder() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        ImageBuilder.prototype.setEdit = function (element, content) {
            var alt = element.find(".alt-edit");
            alt.text(content.alt);
            var src = element.find(".src-edit");
            src.text(content.path);
        };
        ImageBuilder.prototype.setContent = function (element, content) {
            var img = element.find('img').first();
            img.attr("src", content.path);
            img.attr("alt", content.alt);
            return element;
        };
        ImageBuilder.prototype.save = function (element, content) {
            var img = element.find('img').first();
            // bind edit
            var alt = element.find(".alt-edit");
            alt.val(content.alt);
            var src = element.find(".src-edit");
            var save = element.find(".save-btn");
            content.alt = alt.val().toString();
            var file = src.prop('files')[0];
            this.uploadImage(file, content);
        };
        ImageBuilder.prototype.uploadImage = function (file, c) {
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
        };
        return ImageBuilder;
    }(IContentBuilder));
    function remove(element) {
        var index = parseInt(element.attr("id").match(/\d*$/)[0]);
        if (confirm("Delete Element?")) {
            element.remove();
            for (var i = index + 1; i < builder.content.length; i++) {
                $("#Content" + i).attr("id", "Content" + (i - 1));
            }
            builder.content.splice(index, 1);
        }
    }
});
//#endregion
//# sourceMappingURL=pagebuilder.js.map