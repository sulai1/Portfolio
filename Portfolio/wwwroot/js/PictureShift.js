
class Tile {
    constructor(context, img, x, y) {
        this.img = img;
        this.x = x;
        this.y = y;
        this.xStart = x;
        this.yStart = y;
        this.context = context;
    }

    switch(other) {
        this.context.tiles[this.x][this.y] = other;
        this.context.tiles[other.x][other.y] = this;
        var tmpX = other.x;
        var tmpY = other.y;
        other.x = this.x;
        other.y = this.y;
        this.x = tmpX;
        this.y = tmpY;
    }

    isLast() {
        return this.xStart === this.context.numXTiles - 1 && this.yStart === this.context.numYTiles - 1;
    }
    drawBorder() {
        let { dispX, dispY } = this.dispPos(this.context);

        fill(204, 101, 192, 175);
        stroke(255, 63, 120);
        strokeWeight(5.0);
        strokeJoin(ROUND);
        rect(dispX, dispY, this.context.tileWidth, this.context.tileHeight);
    }

    //get the size and position to display the tile at
    dispPos() {
        var u = this.x / this.context.numXTiles;
        var v = this.y / this.context.numYTiles;

        //get the size and position to display the tile at
        var dispX = u * this.context.width;
        var dispY = v * this.context.height;

        return { dispX, dispY };
    }

    draw() {
        let { dispX, dispY } = this.dispPos();

        // modify tile if it is the last
        if (this.isLast()) {
            tint(150, 220, 255, 100);
            image(this.img, dispX, dispY, this.context.tileWidth, this.context.tileHeight);
            this.context.selectedX = this.x;
            this.context.selectedY = this.y;
        } else {
            noTint();
            image(this.img, dispX, dispY, this.context.tileWidth, this.context.tileHeight);
        }
        // check if adjacent to last to draw indication borders
        if (this.isSelectable())
            this.drawBorder();
    }

    isSelectable() {
        if (this.context.last.x === this.x) {
            if (this.context.last.y - 1 === this.y || this.context.last.y + 1 === this.y) {
                return true;
            }
        }
        else if (this.context.last.y === this.y) {
            if (this.context.last.x - 1 === this.x || this.context.last.x + 1 === this.x) {
                return true;
            }
        }
    }
}

class Context {
    constructor(img, numXTiles, numYTiles) {
        this.canvas = null;
        this.changed = false;
        this.img = img;
        this.width = 600;
        this.height = 400;
        this.numXTiles = numXTiles;
        this.numYTiles = numYTiles;
        this.tiles = Array.from(Array(numXTiles), () => new Array(numYTiles));
    }


    getTile(mouseX, mouseY) {
        return this.tiles[Math.floor(mouseX / this.height * this.numYTiles)][Math.floor(mouseY / this.width * this.numXTiles)];
    }

    initCanvas() {
        blendMode(ADD);
        //calculate the width and height
        var el = $('#sketch-holder');
        this.height = el.innerHeight();
        this.width = this.height;

        //create canvas and set its parent in the html document
        this.canvas = createCanvas(this.width, this.height);
        new p5(setup, el);
    }

    initTiles() {
        this.img.loadPixels();

        // calculate tile size
        this.tileWidth = Math.floor(this.img.width / this.numXTiles);
        this.tileHeight = Math.floor(this.img.height / this.numYTiles);


        for (var x = 0; x < this.numXTiles; x++) {
            for (var y = 0; y < this.numYTiles; y++) {
                // create tile and load pixels
                var i = createImage(this.tileWidth, this.tileHeight);
                this.tiles[x][y] = new Tile(vars, i, x, y);
                i.loadPixels();

                // get tile offset
                var xOffset = Math.floor(x / this.numXTiles * this.img.width);
                var yi = Math.floor(y / this.numYTiles * this.img.height);
                for (var xt = 0; xt < i.width; xt++) {
                    for (var yt = 0; yt < i.height; yt++) {
                        var tileIndex = (xt + yt * i.width) * 4;
                        var imageIndex = (xOffset + xt + (yi + yt) * this.img.width) * 4;

                        // set color
                        i.pixels[tileIndex + 0] = this.img.pixels[imageIndex + 0];
                        i.pixels[tileIndex + 1] = this.img.pixels[imageIndex + 1];
                        i.pixels[tileIndex + 2] = this.img.pixels[imageIndex + 2];
                        i.pixels[tileIndex + 3] = this.img.pixels[imageIndex + 3];
                    }
                }

                // update modified pixels
                i.updatePixels();
            }
        }
        this.last = this.tiles[this.numXTiles - 1][this.numYTiles - 1];
    }

    drawImage() {
        image(this.img, 0, 0, this.width, this.height);
    }

    draw() {
        if (this.changed) {
            clear();
            this.drawTiles();
            this.changed = false;
            var finished = true;
            for (var x = 0; x < this.numXTiles; x++) {
                for (var y = 0; y < this.numYTiles; y++) {
                    var tile = this.tiles[x][y];
                    if (tile.xStart !== x || tile.yStart !== y)
                        finished = false;
                }
            }
            if (finished)
                alert("Congratulations!\nYou finished the puzzle");
        }
    }

    drawGrid() {
        // draw horizontal lines
        for (var x = 1; x < this.numXTiles; x++) {
            var u = Math.floor(x / this.numXTiles * this.width);
            line(u, 0, u, this.height);
        }
        // draw vertical lines
        for (var y = 1; y < this.numYTiles; y++) {
            var v = Math.floor(y / this.numYTiles * this.height);
            line(0, v, this.width, v);
        }
    }

    drawTiles() {
        for (var x = 0; x < this.numXTiles; x++) {
            for (var y = 0; y < this.numYTiles; y++) {
                var img = this.tiles[x][y];
                img.draw();
            }
        }
    }


    shuffle() {
        for (var i = 0; i < 10; i++) {
            var r = Math.random();
            var x = this.last.x;
            var y = this.last.y;
            if (r < 0.25) {
                x += 1;
            } else if (r < 0.5) {
                x -= 1;
            } else if (r < 0.75) {
                y += 1;
            } else {
                y -= 1;
            }
            if (x >= 0 && y >= 0 && x < this.numXTiles && y < this.numYTiles)
                this.tiles[x][y].switch(this.last);
        }
    }
}
var vars;

function preload() {
    vars = new Context(loadImage('/images/wooden-ornament.jpg'), 4, 4);
}

function setup() {

    vars.initCanvas();
    vars.initTiles();
    vars.shuffle();
    vars.drawImage();
    vars.drawGrid();
}

function setTileCount(tileCount) {
    vars.changed = true;
    vars.numXTiles = tileCount;
    vars.numYTiles = tileCount;
    vars.initTiles();
    vars.shuffle();
    vars.draw();
}

function setDifficulty(difficulty) {
    vars.changed = true;
    vars.difficulty = difficulty;
    vars.initTiles();
    vars.shuffle();
    vars.draw();
}

function restart() {
    vars.changed = true;
    vars.initTiles();
    vars.shuffle();
    vars.draw();
}


function draw() {
    vars.draw();
}

function setPos() {
    vars.changed = true;
    var tile = vars.getTile(mouseX, mouseY);
    if (tile.isSelectable(vars))
        tile.switch(vars.last);
}