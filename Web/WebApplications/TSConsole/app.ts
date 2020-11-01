import { log } from "console";
import { stdout, stdin } from "process";

class Book {
    public readonly name: string;
    public readonly author: string;
    public readonly topic: string;
    public readonly page_count: number;

    /**
     *
     */
    constructor(name: string, author: string, topic: string, page_count: number) {
        this.name = name;
        this.topic = topic;
        this.author = author;
        this.page_count = page_count;
    }

    method toString()
    {

    };
}

function PrintArray(array: Array<any>): void
{
    for (var item in array)
    {
        log(item.toString());
    }
}

PrintArray([1, 2, 4, 8, 9]);
stdin.read();