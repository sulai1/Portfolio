var draw;
define(['sectionbuilder'], function (sb) {
    draw = function (json) {
        Sectionbuilder.fromJs(json);
    }
})