"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var assert = require("assert");
var fs = require("fs");
function Test1() {
    fs.readFile("../Shared/res/json/schema.json", function (err, data) {
        if (err) {
            return console.error(err);
        }
        var json = JSON.parse(data.toString());
        var builder = JSON.parse(data.toString());
        assert(true);
    });
}
exports.Test1 = Test1;
;
//# sourceMappingURL=test.js.map