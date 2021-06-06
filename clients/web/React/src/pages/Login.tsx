import React, {SyntheticEvent, useState} from 'react';
import {Redirect} from 'react-router-dom';

const Login = (props: { setFirstName: (name: string)=> void }) => {
    
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [redirect, setRedirect] = useState(false);

    const submit = async (e: SyntheticEvent) => {


    e.preventDefault();
    
       let url = 'https://localhost:44321/api';
       let uri =  url + '/User/Login/' + email + '&' + password;
        
        const response = await fetch(uri , {
            method: 'GET',
            credentials:'include',
        })

        const content = await response.json();
        
        
        setRedirect(true);
        
        console.log(content)  ;
        props.setFirstName(content.firstName);
    }

    if(redirect){
        return  <Redirect to="/" />
    }

    return (
        <form onSubmit={submit}>
            <h1 className="h3 mb-3 fw-normal">Empty</h1>
            <h1 className="h3 mb-3 fw-normal">Please sign in</h1>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="name@example.com" onChange={e => setEmail(e.target.value)}/>
                <label htmlFor="floatingInput">Email address</label>
            </div>
            <div className="form-floating">
                <input type="password" className="form-control"
                       placeholder="Password" onChange={e => setPassword(e.target.value)}/>
                <label htmlFor="floatingPassword">Password</label>

            </div>


            <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>
           
        </form>
    );
};

export default Login;