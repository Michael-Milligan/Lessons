"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const console_1 = require("console");
const process_1 = require("process");
class Book {
    /**
     *
     */
    constructor(name, author, topic, page_count) {
        this.name = name;
        this.topic = topic;
        this.author = author;
        this.page_count = page_count;
    }
}
function PrintArray(array) {
    for (var item in array) {
        console_1.log(item.toString());
    }
}
PrintArray([1, 2, 4, 8, 9]);
process_1.stdin.read();
//# sourceMappingURL=app.js.map