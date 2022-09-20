import Link from "next/link";
import { signIn, signOut, useSession } from "next-auth/react";

export const Navbar = () => {

    const { data: session, status } = useSession();

    return (
    <nav className="header">
        <h1 className="logo">
            <a href="#">Productify</a>
        </h1>
        <ul className={`main-nav ${!session && (status == "loading") ? 'loading' : 'loaded'}`}>
            <li>
                <Link href="/">
                    <a>Home</a>
                </Link>
            </li>
            {session && (
                <li>
                    <Link href="/projects">
                        <a>Projects</a>
                    </Link>
                </li>
            )}
            {!(status == "loading") && !session && (
                <li>
                    <Link href="/api/auth/signin">
                        <a onClick={e => {
                            e.preventDefault()
                            signIn()
                        }}>Sign in</a>
                    </Link>
                </li>
            )}
            {session && (
                <li>
                    <Link href="/api/auth/signout">
                        <a onClick={e => {
                            e.preventDefault()
                            signOut()
                        }}>Sign out</a>
                    </Link>
                </li>
            )}
        </ul>
    </nav>
    );
}