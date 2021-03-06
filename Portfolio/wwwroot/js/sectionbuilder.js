/*eslint eqeqeq: ["error", "smart"]*/
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v9.10.57.0 (Newtonsoft.Json v11.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------
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
define(["require", "exports"], function (require, exports) {
    "use strict";
    exports.__esModule = true;
    var IContent = /** @class */ (function () {
        function IContent(data) {
            if (data) {
                for (var property in data) {
                    if (data.hasOwnProperty(property))
                        this[property] = data[property];
                }
            }
            this._discriminator = "IContent";
        }
        IContent.prototype.init = function (data) {
            if (data) {
            }
        };
        IContent.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            if (data["discriminator"] === "TextContent") {
                var result = new TextContent();
                result.init(data);
                return result;
            }
            if (data["discriminator"] === "CodeContent") {
                var result = new CodeContent();
                result.init(data);
                return result;
            }
            if (data["discriminator"] === "ExampleContent") {
                var result = new ExampleContent();
                result.init(data);
                return result;
            }
            if (data["discriminator"] === "ImageContent") {
                var result = new ImageContent();
                result.init(data);
                return result;
            }
            throw new Error("The abstract class 'IContent' cannot be instantiated.");
        };
        IContent.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            data["discriminator"] = this._discriminator;
            return data;
        };
        return IContent;
    }());
    exports.IContent = IContent;
    var TextContent = /** @class */ (function (_super) {
        __extends(TextContent, _super);
        function TextContent(data) {
            var _this = _super.call(this, data) || this;
            _this._discriminator = "TextContent";
            return _this;
        }
        TextContent.prototype.init = function (data) {
            _super.prototype.init.call(this, data);
            if (data) {
                this.text = data["Text"];
            }
        };
        TextContent.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            if (data["discriminator"] === "CodeContent") {
                var result_1 = new CodeContent();
                result_1.init(data);
                return result_1;
            }
            if (data["discriminator"] === "ExampleContent") {
                var result_2 = new ExampleContent();
                result_2.init(data);
                return result_2;
            }
            var result = new TextContent();
            result.init(data);
            return result;
        };
        TextContent.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            data["Text"] = this.text;
            _super.prototype.toJSON.call(this, data);
            return data;
        };
        return TextContent;
    }(IContent));
    exports.TextContent = TextContent;
    var CodeContent = /** @class */ (function (_super) {
        __extends(CodeContent, _super);
        function CodeContent(data) {
            var _this = _super.call(this, data) || this;
            _this._discriminator = "CodeContent";
            return _this;
        }
        CodeContent.prototype.init = function (data) {
            _super.prototype.init.call(this, data);
            if (data) {
                this.type = data["Type"];
            }
        };
        CodeContent.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            if (data["discriminator"] === "ExampleContent") {
                var result_3 = new ExampleContent();
                result_3.init(data);
                return result_3;
            }
            var result = new CodeContent();
            result.init(data);
            return result;
        };
        CodeContent.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            data["Type"] = this.type;
            _super.prototype.toJSON.call(this, data);
            return data;
        };
        return CodeContent;
    }(TextContent));
    exports.CodeContent = CodeContent;
    var ExampleContent = /** @class */ (function (_super) {
        __extends(ExampleContent, _super);
        function ExampleContent(data) {
            var _this = _super.call(this, data) || this;
            _this._discriminator = "ExampleContent";
            return _this;
        }
        ExampleContent.prototype.init = function (data) {
            _super.prototype.init.call(this, data);
            if (data) {
            }
        };
        ExampleContent.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            var result = new ExampleContent();
            result.init(data);
            return result;
        };
        ExampleContent.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            _super.prototype.toJSON.call(this, data);
            return data;
        };
        return ExampleContent;
    }(CodeContent));
    exports.ExampleContent = ExampleContent;
    var ImageContent = /** @class */ (function (_super) {
        __extends(ImageContent, _super);
        function ImageContent(data) {
            var _this = _super.call(this, data) || this;
            _this._discriminator = "ImageContent";
            return _this;
        }
        ImageContent.prototype.init = function (data) {
            _super.prototype.init.call(this, data);
            if (data) {
                this.path = data["Path"];
                this.alt = data["Alt"];
            }
        };
        ImageContent.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            var result = new ImageContent();
            result.init(data);
            return result;
        };
        ImageContent.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            data["Path"] = this.path;
            data["Alt"] = this.alt;
            _super.prototype.toJSON.call(this, data);
            return data;
        };
        return ImageContent;
    }(IContent));
    exports.ImageContent = ImageContent;
    var SectionBuilder = /** @class */ (function () {
        function SectionBuilder(data) {
            if (data) {
                for (var property in data) {
                    if (data.hasOwnProperty(property))
                        this[property] = data[property];
                }
            }
        }
        SectionBuilder.prototype.init = function (data) {
            if (data) {
                this.id = data["Id"];
                this.title = data["Title"];
                if (data["Content"] && data["Content"].constructor === Array) {
                    this.content = [];
                    for (var _i = 0, _a = data["Content"]; _i < _a.length; _i++) {
                        var item = _a[_i];
                        this.content.push(IContent.fromJS(item));
                    }
                }
            }
        };
        SectionBuilder.fromJS = function (data) {
            data = typeof data === 'object' ? data : {};
            var result = new SectionBuilder();
            result.init(data);
            return result;
        };
        SectionBuilder.prototype.toJSON = function (data) {
            data = typeof data === 'object' ? data : {};
            data["Id"] = this.id;
            data["Title"] = this.title;
            if (this.content && this.content.constructor === Array) {
                data["Content"] = [];
                for (var _i = 0, _a = this.content; _i < _a.length; _i++) {
                    var item = _a[_i];
                    data["Content"].push(item.toJSON());
                }
            }
            return data;
        };
        return SectionBuilder;
    }());
    exports.SectionBuilder = SectionBuilder;
});
//# sourceMappingURL=sectionbuilder.js.map