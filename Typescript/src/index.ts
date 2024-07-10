interface OutputFormat {
    name: string;
    kind: string;
    value: number | string;
}

type Dimensions = {
    width: number;
    height: number;
    depth: number;
};

type Kind = "Ratio" | "Volume" | "DateTime";



function generateKindObject(dimensions: Dimensions, kind: Kind,index: number): OutputFormat {
    let value: number | string;

    switch (kind) {
        case "Ratio":
            value = dimensions.width / dimensions.height;
            break;
        case "Volume":
            value = dimensions.width * dimensions.height * dimensions.depth;
            break;
        case "DateTime":
            value = new Date().toLocaleString();
            break;
        default:
            throw new Error("Invalid kind provided");
    }

    return {
        name: `object${index}`,
        kind: kind.toLowerCase(),
        value: value
    };
}

// Test the function
const dimensions: Dimensions = {
    width: 300,
    height: 600,
    depth: 800
};

const kinds: Kind[] = ["Ratio", "Volume", "DateTime"];

kinds.forEach((kind, index) => {
    console.log(generateKindObject(dimensions, kind,(index+1)));
});
