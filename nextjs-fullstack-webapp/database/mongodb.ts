//import { MongoClientOptions } from './../node_modules/mongodb/src/mongo_client';
import { MongoClient } from "mongodb"

const uri = process.env.MONGO_URL as string
// const options = {
//   useUnifiedTopology: true,
// } as MongoClientOptions

let client
let clientPromise

if (!process.env.MONGO_URL) {
  throw new Error("Please add your Mongo URI to .env.local")
}

client = new MongoClient(uri)
clientPromise = client.connect()

export default clientPromise as Promise<MongoClient>