class Book
{
    constructor(pages, topic) 
    {
        this.pages = pages;
        this.topic = topic;
    }

    toString()
    {
        return `This book is about ${this.topic} and has ${this.pages} pages`;
    }
}

a = new Book(251, 'Chemistry');
console.log(a.toString());