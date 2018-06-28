"use strict";

var pagebuilder;
(function (pagebuilder) {
    function draw(json) {
        console.log(json);
        //let sb = SectionBuilder.fromJS(JSON.parse(json));
        //let e = document.createElement('hi');
        //e.id = 'title';
        //e.attributes['color'] = 255;
        //document.insertBefore(e, document.getElementById("container"));
    }
    pagebuilder.draw = draw;
})(pagebuilder || (pagebuilder = {}));
//# sourceMappingURL=pagebuilder.js.map

