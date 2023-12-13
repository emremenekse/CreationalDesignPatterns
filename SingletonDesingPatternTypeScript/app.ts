

class Database {

    private constructor() {
        console.log("Created");
    }

    private static _database: Database;

    static get getInstance() {
        if (this._database == null) {
            this._database = new Database();
        }
        return this._database;
    }
    private count?: number = 1;
    connection() {
        console.log("Connected");
        if (this.count) {
            console.log(this.count++);

        }
    }


}

let d1: Database = Database.getInstance;
d1.connection();
let d2: Database = Database.getInstance;
d1.connection();
let d3: Database = Database.getInstance;
d1.connection();

