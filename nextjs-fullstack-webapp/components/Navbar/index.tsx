import Link from "next/link";
import { signIn, signOut } from "next-auth/react";

export const Navbar = () => {
    return (
    <nav className="header">
        <h1 className="logo">
            <a href="#">Productify</a>
        </h1>
        <ul className={`main-nav`}>
            <li>
                <Link href="/api/auth/signin">
                    <a onClick={e => {
                        e.preventDefault()
                        signIn()
                    }}>Sign in</a>
                </Link>
            </li>
            <li>
                <Link href="/api/auth/signout">
                    <a onClick={e => {
                        e.preventDefault()
                        signOut()
                    }}>Sign out</a>
                </Link>
            </li>
        </ul>
    </nav>
    );
}