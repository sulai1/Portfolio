//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v9.10.56.0 (Newtonsoft.Json v11.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------





export class SubSection implements ISubSection {
    title: string;

    constructor(data?: ISubSection) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.title = data["Title"];
        }
    }

    static fromJS(data: any): SubSection {
        data = typeof data === 'object' ? data : {};
        let result = new SubSection();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Title"] = this.title;
        return data; 
    }
}

export interface ISubSection {
    title: string;
}

export abstract class IContent implements IIContent {

    protected _discriminator: string;

    constructor(data?: IIContent) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        this._discriminator = "IContent";
    }

    init(data?: any) {
        if (data) {
        }
    }

    static fromJS(data: any): IContent {
        data = typeof data === 'object' ? data : {};
        if (data["discriminator"] === "TextContent") {
            let result = new TextContent();
            result.init(data);
            return result;
        }
        if (data["discriminator"] === "CodeContent") {
            let result = new CodeContent();
            result.init(data);
            return result;
        }
        if (data["discriminator"] === "ExampleContent") {
            let result = new ExampleContent();
            result.init(data);
            return result;
        }
        if (data["discriminator"] === "ImageContent") {
            let result = new ImageContent();
            result.init(data);
            return result;
        }
        throw new Error("The abstract class 'IContent' cannot be instantiated.");
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["discriminator"] = this._discriminator; 
        return data; 
    }
}

export interface IIContent {
}

export class TextContent extends IContent implements ITextContent {
    text: string;

    constructor(data?: ITextContent) {
        super(data);
        this._discriminator = "TextContent";
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.text = data["Text"];
        }
    }

    static fromJS(data: any): TextContent {
        data = typeof data === 'object' ? data : {};
        if (data["discriminator"] === "CodeContent") {
            let result = new CodeContent();
            result.init(data);
            return result;
        }
        if (data["discriminator"] === "ExampleContent") {
            let result = new ExampleContent();
            result.init(data);
            return result;
        }
        let result = new TextContent();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Text"] = this.text;
        super.toJSON(data);
        return data; 
    }
}

export interface ITextContent extends IIContent {
    text: string;
}

export class CodeContent extends TextContent implements ICodeContent {
    type: string;

    constructor(data?: ICodeContent) {
        super(data);
        this._discriminator = "CodeContent";
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.type = data["Type"];
        }
    }

    static fromJS(data: any): CodeContent {
        data = typeof data === 'object' ? data : {};
        if (data["discriminator"] === "ExampleContent") {
            let result = new ExampleContent();
            result.init(data);
            return result;
        }
        let result = new CodeContent();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Type"] = this.type;
        super.toJSON(data);
        return data; 
    }
}

export interface ICodeContent extends ITextContent {
    type: string;
}

export class ExampleContent extends CodeContent implements IExampleContent {

    constructor(data?: IExampleContent) {
        super(data);
        this._discriminator = "ExampleContent";
    }

    init(data?: any) {
        super.init(data);
        if (data) {
        }
    }

    static fromJS(data: any): ExampleContent {
        data = typeof data === 'object' ? data : {};
        let result = new ExampleContent();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        super.toJSON(data);
        return data; 
    }
}

export interface IExampleContent extends ICodeContent {
}

export class ImageContent extends IContent implements IImageContent {
    path: string;
    alt: string;

    constructor(data?: IImageContent) {
        super(data);
        this._discriminator = "ImageContent";
    }

    init(data?: any) {
        super.init(data);
        if (data) {
            this.path = data["Path"];
            this.alt = data["Alt"];
        }
    }

    static fromJS(data: any): ImageContent {
        data = typeof data === 'object' ? data : {};
        let result = new ImageContent();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Path"] = this.path;
        data["Alt"] = this.alt;
        super.toJSON(data);
        return data; 
    }
}

export interface IImageContent extends IIContent {
    path: string;
    alt: string;
}

export class SectionBuilder implements ISectionBuilder {
    title: string;
    subSections: SubSection[];
    content: IContent[];

    constructor(data?: ISectionBuilder) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.title = data["Title"];
            if (data["SubSections"] && data["SubSections"].constructor === Array) {
                this.subSections = [];
                for (let item of data["SubSections"])
                    this.subSections.push(SubSection.fromJS(item));
            }
            if (data["Content"] && data["Content"].constructor === Array) {
                this.content = [];
                for (let item of data["Content"])
                    this.content.push(IContent.fromJS(item));
            }
        }
    }

    static fromJS(data: any): SectionBuilder {
        data = typeof data === 'object' ? data : {};
        let result = new SectionBuilder();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Title"] = this.title;
        if (this.subSections && this.subSections.constructor === Array) {
            data["SubSections"] = [];
            for (let item of this.subSections)
                data["SubSections"].push(item.toJSON());
        }
        if (this.content && this.content.constructor === Array) {
            data["Content"] = [];
            for (let item of this.content)
                data["Content"].push(item.toJSON());
        }
        return data; 
    }
}

export interface ISectionBuilder {
    title: string;
    subSections: SubSection[];
    content: IContent[];
}