"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var assert = require("assert");
var fs = require("fs");
var all = require("../Shared/res/ts/object");
function Test1() {
    fs.readFile("../Shared/res/json/object.json", function (err, data) {
        if (err) {
            return console.error(err);
        }
        var json = JSON.parse(data.toString());
        var builder = all.SectionBuilder.fromJS(JSON.parse(data.toString()));
        assert(builder["Title"] == "test");
    });
}
exports.Test1 = Test1;
;
//# sourceMappingURL=test.js.map