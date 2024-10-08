﻿db = db.getSiblingDB('SalesDB'); 

db.createCollection("Books", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["Name", "Price", "Category", "Author"],
            properties: {
                _id: {
                    bsonType: "objectId",
                    description: "'_id' must be an ObjectId and is required."
                },
                Name: {
                    bsonType: "string",
                    description: "'Name' must be a string and is required."
                },
                Price: {
                    "bsonType": "double",
                    "minimum": 0,
                    "description": "'Price' must be a positive decimal number and is required."
                },
                Category: {
                    bsonType: "string",
                    description: "'Category' must be a string and is required."
                },
                Author: {
                    bsonType: "string",
                    description: "'Author' must be a string and is required."
                }
            }
        }
    },
    validationLevel: "strict",
    validationAction: "error"
})

db.createCollection("Users", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["name", "age", "email", "location"],
            properties: {
                name: {
                    bsonType: "string",
                    description: "The 'name' field must be a string and is required."
                },
                age: {
                    bsonType: "int",
                    minimum: 18,
                    maximum: 100,
                    description: "The 'age' field must be an integer between 18 and 100 and is required."
                },
                email: {
                    bsonType: "string",
                    pattern: "^.+@.+\\..+$",
                    description: "The 'email' field must be a valid email format."
                },
                location: {
                    bsonType: "string",
                    description: "The 'location' field must be a string and is required."
                }
            }
        }
    },
    validationLevel: "strict",
    validationAction: "error"
})

db.createCollection("Orders", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["userId", "total", "items", "date"],
            properties: {
                userId: {
                    bsonType: "objectId",
                    description: "The 'userId' must be an integer and is required."
                },
                total: {
                    bsonType: "double",
                    minimum: 0,
                    description: "The 'total' must be a positive double and is required."
                },
                items: {
                    bsonType: "array",
                    minItems: 1,
                    items: {
                        bsonType: "string"
                    },
                    description: "The 'items' field must be an array of strings and must contain at least one item."
                },
                date: {
                    bsonType: "string",
                    pattern: "^(\\d{4}-\\d{2}-\\d{2})$",
                    description: "The 'date' must be a string in the format YYYY-MM-DD and is required."
                }
            }
        }
    },
    validationLevel: "strict",
    validationAction: "error"
})

db.Books.insertMany([
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f01"), "Name": "Design Patterns", "Price": 54.93, "Category": "Computers", "Author": "Ralph Johnson" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f02"), "Name": "Clean Code", "Price": 43.15, "Category": "Computers", "Author": "Robert C. Martin" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f03"), "Name": "The Pragmatic Programmer", "Price": 48.99, "Category": "Computers", "Author": "Andrew Hunt" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f04"), "Name": "Refactoring", "Price": 58.67, "Category": "Computers", "Author": "Martin Fowler" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f05"), "Name": "Introduction to Algorithms", "Price": 102.95, "Category": "Computers", "Author": "Thomas H. Cormen" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f06"), "Name": "Code Complete", "Price": 55.89, "Category": "Computers", "Author": "Steve McConnell" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f07"), "Name": "The Mythical Man-Month", "Price": 34.97, "Category": "Computers", "Author": "Frederick P. Brooks Jr." },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f08"), "Name": "The Clean Coder", "Price": 38.73, "Category": "Computers", "Author": "Robert C. Martin" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f09"), "Name": "Head First Design Patterns", "Price": 44.99, "Category": "Computers", "Author": "Eric Freeman" },
    { _id: ObjectId("6514b9f0a1b9a1a7c8d48f0a"), "Name": "Patterns of Enterprise Application Architecture", "Price": 60.87, "Category": "Computers", "Author": "Martin Fowler" }
])

db.Users.insertMany([
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a001"), "name": "John Doe", "age": 30, "location": "New York", "email": "johndoe@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a002"), "name": "Jane Smith", "age": 25, "location": "Los Angeles", "email": "janesmith@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a003"), "name": "Alice Johnson", "age": 35, "location": "Chicago", "email": "alicej@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a004"), "name": "Bob Brown", "age": 40, "location": "Miami", "email": "bobbrown@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a005"), "name": "Charlie Green", "age": 28, "location": "Dallas", "email": "charlieg@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a006"), "name": "Diana White", "age": 32, "location": "San Francisco", "email": "dianawhite@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a007"), "name": "Eve Black", "age": 29, "location": "Boston", "email": "eveblack@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a008"), "name": "Frank Wilson", "age": 33, "location": "Houston", "email": "frankw@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a009"), "name": "Grace Lee", "age": 31, "location": "Seattle", "email": "gracelee@example.com" },
    { "_id": ObjectId("650a7e2f6e4a4f1bcd77a00a"), "name": "Henry Adams", "age": 27, "location": "Denver", "email": "henryadams@example.com" }
])

db.Orders.insertMany([
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a001"), "total": 250.50, "items": ["Laptop", "Mouse"], "date": "2024-09-01" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a002"), "total": 150.10, "items": ["Tablet", "Keyboard"], "date": "2024-09-05" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a003"), "total": 500.25, "items": ["Monitor", "Printer"], "date": "2024-09-07" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a004"), "total": 75.75, "items": ["Headphones"], "date": "2024-09-10" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a005"), "total": 99.99, "items": ["Smartwatch"], "date": "2024-09-12" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a006"), "total": 200.99, "items": ["Phone", "Charger"], "date": "2024-09-14" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a007"), "total": 300.80, "items": ["Camera", "Tripod"], "date": "2024-09-15" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a008"), "total": 45.70, "items": ["Book"], "date": "2024-09-17" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a009"), "total": 120.60, "items": ["Backpack", "Shoes"], "date": "2024-09-18" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a00a"), "total": 350.50, "items": ["Drone", "Spare Battery"], "date": "2024-09-20" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a001"), "total": 1400.11, "items": ["Smartphone", "Charger"], "date": "2023-09-02" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a002"), "total": 300.22, "items": ["Headphones"], "date": "2023-09-03" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a003"), "total": 600.21, "items": ["Tablet"], "date": "2023-09-04" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a004"), "total": 400.01, "items": ["Monitor"], "date": "2023-09-05" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a005"), "total": 100.02, "items": ["Keyboard", "Mouse"], "date": "2023-09-06" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a006"), "total": 75.09, "items": ["Mouse"], "date": "2023-09-07" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a007"), "total": 150.56, "items": ["Webcam"], "date": "2023-09-08" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a008"), "total": 200.51, "items": ["Printer"], "date": "2023-09-09" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a009"), "total": 250.87, "items": ["Smartwatch"], "date": "2023-09-10" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a00a"), "total": 100.98, "items": ["Router"], "date": "2023-09-11" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a001"), "total": 45.99, "items": ["Charger"], "date": "2023-09-12" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a002"), "total": 500.90, "items": ["Graphics Card"], "date": "2023-09-13" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a003"), "total": 200.99, "items": ["SSD"], "date": "2023-09-14" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a004"), "total": 50.01, "items": ["USB Hub"], "date": "2023-09-15" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a005"), "total": 120.05, "items": ["Speaker"], "date": "2023-09-16" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a006"), "total": 30.01, "items": ["Bluetooth Adapter"], "date": "2023-09-17" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a007"), "total": 80.90, "items": ["Phone Case"], "date": "2023-09-18" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a008"), "total": 150.08, "items": ["External Hard Drive"], "date": "2023-09-19" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a009"), "total": 60.07, "items": ["Laptop Stand"], "date": "2023-09-20" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a00a"), "total": 70.91, "items": ["Game Controller"], "date": "2023-09-21" },
    { "userId": ObjectId("650a7e2f6e4a4f1bcd77a00a"), "total": 1200.94, "items": ["Laptop"], "date": "2023-09-01" }
])
