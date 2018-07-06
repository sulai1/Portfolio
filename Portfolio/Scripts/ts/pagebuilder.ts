
function draw(json: string) {
    var pb = require('.pagebuilder');
    let builder = pb.fromJS(json);
    console.log(builder.title);
    //let sb = SectionBuilder.fromJS(JSON.parse(json));
    //let e = document.createElement('hi');
    //e.id = 'title';
    //e.attributes['color'] = 255;
    //document.insertBefore(e, document.getElementById("container"));
}
