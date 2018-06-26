import assert = require('assert');
import fs = require('fs');
import * as all from "../Shared/res/ts/object";

export function Test1() {
    fs.readFile("../Shared/res/json/schema.json", function (err, data) {
        if (err) {
            return console.error(err);
        }
        let json  = JSON.parse(data.toString());
        let builder: all.SectionBuilder = JSON.parse(data.toString());
        assert(true);
    });
};
