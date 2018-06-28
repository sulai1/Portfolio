
var p5;
var last;
var numXTiles = 4;
var numYTiles = 4;
var tileWidth;
var tileHeight;
var tiles;
var swap;
var changed = true;
var reset;
var difficulty = 10;


function setDifficulty(diff) {
    changed = true;
    difficulty = diff;
    reset()
}

function restart() {
    changed = true;
    reset();
}

function getTile(mouseX, mouseY) {
    return tiles[Math.floor(p5.mouseX / p5.height * numYTiles)][Math.floor(p5.mouseY / p5.width * numXTiles)];
}

function setPos() {
    changed = true;
    var tile = getTile(p5.mouseX, p5.mouseY);
    if (tile.isSelectable())
        swap(tile,last);
}

var sketch = function (p) {
    var img;
    var width;
    var height;

    p.preload = function () {
        img = p.loadImage('/images/wooden-ornament.jpg');
        p5 = p;
    }

    p.draw = function () {
        draw();
    }

    p.setup = function () {
        initCanvas();
        initTiles();
        shuffle();
    }


    var getTile = function (mouseX, mouseY) {
        return tiles[Math.floor(mouseX / height * numYTiles)][Math.floor(mouseY / width * numXTiles)];
    }

    var draw = function () {
        if (changed) {
            p.background(0);
            drawTiles();
            changed = false;
            finished = true;
            for (var x = 0; x < numXTiles; x++) {
                for (var y = 0; y < numYTiles; y++) {
                    var tile = tiles[x][y];
                    if (tile.xStart !== x || tile.yStart !== y)
                        finished = false;
                }
            }
            if (finished)
                alert("Congratulations!\nYou finished the puzzle");
        }
    }

    var drawTiles = function () {
        for (var x = 0; x < numXTiles; x++) {
            for (var y = 0; y < numYTiles; y++) {
                var t = tiles[x][y];
                t.draw();
            }
        }
    }

    var initCanvas = function () {
        let el = document.getElementById("sketch");
        width = el.offsetHeight;
        height = el.offsetHeight;
        //create canvas and set its parent in the html document
        p.createCanvas(width, height);
    }

    reset = function () {
        changed = true;
        initTiles();
        shuffle();
        draw();
    }

    var initTiles = function () {
        img.loadPixels();

        // calculate tile size
        tileWidth = Math.floor(img.width / numXTiles);
        tileHeight = Math.floor(img.height / numYTiles);

        tiles = Array.from(Array(numXTiles), () => new Array(numYTiles));

        for (var x = 0; x < numXTiles; x++) {
            for (var y = 0; y < numYTiles; y++) {
                // create tile and load pixels
                var i = p.createImage(tileWidth, tileHeight);
                tiles[x][y] = new Tile(sketch, i, x, y);
                i.loadPixels();

                // get tile offset
                var xOffset = Math.floor(x / numXTiles * img.width);
                var yi = Math.floor(y / numYTiles * img.height);
                for (var xt = 0; xt < i.width; xt++) {
                    for (var yt = 0; yt < i.height; yt++) {
                        var tileIndex = (xt + yt * i.width) * 4;
                        var imageIndex = (xOffset + xt + (yi + yt) * img.width) * 4;

                        // set color
                        i.pixels[tileIndex + 0] = img.pixels[imageIndex + 0];
                        i.pixels[tileIndex + 1] = img.pixels[imageIndex + 1];
                        i.pixels[tileIndex + 2] = img.pixels[imageIndex + 2];
                        i.pixels[tileIndex + 3] = img.pixels[imageIndex + 3];
                    }
                }

                // update modified pixels
                i.updatePixels();
            }
        }
        last = tiles[numXTiles - 1][numYTiles - 1];
    }

    var shuffle = function () {
        for (var i = 0; i < difficulty; i++) {
            var r = Math.random();
            var x = last.x;
            var y = last.y;
            if (r < 0.25) {
                x += 1;
            } else if (r < 0.5) {
                x -= 1;
            } else if (r < 0.75) {
                y += 1;
            } else {
                y -= 1;
            }
            if (x >= 0 && y >= 0 && x < numXTiles && y < numYTiles)
                swap(tiles[x][y], last);
        }
    }
    swap = function (o, other) {
        tiles[o.x][o.y] = other;
        tiles[other.x][other.y] = o;
        var tmpX = other.x;
        var tmpY = other.y;
        other.x = o.x;
        other.y = o.y;
        o.x = tmpX;
        o.y = tmpY;
    }

}
new p5(sketch, window.document.getElementById('sketch'));


class Tile {
    constructor(context, img, x, y) {
        this.img = img;
        this.x = x;
        this.y = y;
        this.xStart = x;
        this.yStart = y;
        this.context = context;
    }

    isLast() {
        return this.xStart === numXTiles - 1 && this.yStart === numYTiles - 1;
    }
    //get the size and position to display the tile at
    dispPos() {
        var u = this.x / numXTiles;
        var v = this.y / numYTiles;

        //get the size and position to display the tile at
        var dispX = u * p5.width;
        var dispY = v * p5.height;

        return { dispX, dispY };
    }

    draw() {
        let { dispX, dispY } = this.dispPos();

        // modify tile if it is the last
        if (this.isLast()) {
            p5.tint(150, 220, 255, 100);
            p5.image(this.img, dispX, dispY, this.context.tileWidth, this.context.tileHeight);
            this.context.selectedX = this.x;
            this.context.selectedY = this.y;
        } else {
            p5.noTint();
            p5.image(this.img, dispX, dispY, this.context.tileWidth, this.context.tileHeight);
        }
        // check if adjacent to last to draw indication borders
        if (this.isSelectable())
            this.drawBorder();
    }

    drawBorder() {
        let { dispX, dispY } = this.dispPos(this.context);

        p5.fill(204, 101, 192, 175);
        p5.stroke(255, 63, 120);
        p5.strokeWeight(5.0);
        p5.strokeJoin(p5.ROUND);
        p5.rect(dispX, dispY, tileWidth, tileHeight);
    }

    isSelectable() {
        if (last.x === this.x) {
            if (last.y - 1 === this.y || last.y + 1 === this.y) {
                return true;
            }
        }
        else if (last.y === this.y) {
            if (last.x - 1 === this.x || last.x + 1 === this.x) {
                return true;
            }
        }
    }
}
