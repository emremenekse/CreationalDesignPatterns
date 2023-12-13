"use strict";
class Database {
    constructor() {
        this.count = 1;
        console.log("Created");
    }
    static get getInstance() {
        if (this._database == null) {
            this._database = new Database();
        }
        return this._database;
    }
    connection() {
        console.log("Connected");
        if (this.count) {
            console.log(this.count++);
        }
    }
}
let d1 = Database.getInstance;
d1.connection();
let d2 = Database.getInstance;
d1.connection();
let d3 = Database.getInstance;
d1.connection();
//# sourceMappingURL=app.js.map