import React from 'react';
import {Link} from "react-router-dom";

const Nav = (props: {firstName : string, setFirstName: (name: string)=> void } ) => {
    
    const  logout = async ()=>{
        await fetch('https://localhost:44321/api/User/Logout', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',}
         )
        props.setFirstName('');
        
        } 


    let menu;
    
    if(props.firstName ===''){
        menu = (

            <ul className="navbar-nav me-auto mb-2 mb-md-0">
                <li className="nav-item">
                    <Link to="/login" className="nav-link active" >Login</Link>
                </li>
                <li className="nav-item">
                    <Link to="/register" className="nav-link active" >Register</Link>
                </li>
            </ul>
        )}else{menu = (
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
              
                <li className="nav-item">
                    <Link to="/register" className="nav-link active" onClick={logout} >Logout</Link>
                </li>
            </ul>
        )
            
        }
    
    
    return (
        <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <div className="container-fluid">
                <Link to="/" className="navbar-brand">Home</Link>

                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                        data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false"
                        aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
            </div>
            <div className="collapse navbar-collapse" id="navbarCollapse">
                {menu}
            </div>
        </nav>
    );
};

export default Nav;