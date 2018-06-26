import assert = require('assert');
import fs = require('fs');
import * as all from "../Shared/res/ts/object";

export function Test1() {
    fs.readFile("../Shared/res/json/object.json", function (err, data) {
        if (err) {
            return console.error(err);
        }
        let builder= all.SectionBuilder.fromJS(JSON.parse(data.toString()));
        assert(builder.title == "test");
    });
};
