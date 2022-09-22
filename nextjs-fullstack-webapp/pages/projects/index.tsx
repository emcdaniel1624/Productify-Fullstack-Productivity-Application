import { NextPage } from "next";
import { getSession, signIn } from "next-auth/react";
import { useEffect, useState } from "react";

const ProjectsPage : NextPage = () => {

    const [ loading, setLoading ] = useState(true);

    useEffect(() => {
        const securePage = async () => {
            const session = await getSession();
            console.log(session)
            if(!session) {
                signIn();
            }
            else {
                setLoading(false);
            }
        }
        securePage();
    }, [])

    if(loading) {
        return ( <>Loading...</> )
    }
    return (
        <><br/><br/><br/><br/>Projects Page</>
    )
}

export default ProjectsPage