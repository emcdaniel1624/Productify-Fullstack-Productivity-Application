import NextAuth from 'next-auth'
import GitHubProvider from 'next-auth/providers/github'
import { MongoDBAdapter } from "@next-auth/mongodb-adapter"
import clientPromise from "../../../database/mongodb"

export default NextAuth({
    providers: [
        GitHubProvider({
            clientId: process.env.GITHUB_ID as string,
            clientSecret: process.env.GITHUB_SECRET as string
        }),
    ],
    adapter: MongoDBAdapter(clientPromise),
    jwt: {
        secret: 'aasdkjvbajbvalerbvalier'
    }
    
})