export class ProductModel{
    id : number;
    description : string;
    code : string;
    price : number;
    grossWeight : number;
    netWeight : number;

    constructor() {
        this.id = 0;
        this.code = '';
        this.description = '';
        this.grossWeight = 0;
        this.netWeight = 0;
        this.price = 0;
    }
}