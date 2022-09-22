import NextAuth from 'next-auth'
import GitHubProvider from 'next-auth/providers/github'
import GoogleProvider from 'next-auth/providers/google'
import { MongoDBAdapter } from "@next-auth/mongodb-adapter"
import clientPromise from "../../../database/mongodb"

export default NextAuth({
    providers: [
        GitHubProvider({
            clientId: process.env.GITHUB_ID as string,
            clientSecret: process.env.GITHUB_SECRET as string
        }),
        GoogleProvider({
            clientId: process.env.GOOGLE_ID as string,
            clientSecret: process.env.GOOGLE_SECRET as string
        })
    ],
    adapter: MongoDBAdapter(clientPromise),
    session: {
        strategy:'jwt'
    },
    jwt: {
        secret: 'aasdkjvbajbvalerbvalier'
    },
    callbacks: {
        async jwt({token,user}) {
            if(user) {
                token.id = user.id
            }
            return token
        },
        async session({session, token}){
            console.log(token)
            session.user.id = token.id
            return session
        }
    }
})