import React, { useState} from 'react';
import './App.css';
import Login from "./pages/Login";
import Nav from "./components/Nav";
import {BrowserRouter, Route} from "react-router-dom"
import Home from "./pages/Home";
import Register from "./pages/Register";



function App() {

    
    const [firstName, setFirstName] = useState('');
   
    
    return (
        <div className="App">
            <BrowserRouter>

                <Nav firstName={firstName} setFirstName={setFirstName}/>
                <main className="form-signin">

                    <Route path="/"  component={()=> <Home firstName={firstName} />}></Route>
                    <Route path="/login" component={()=><Login setFirstName={setFirstName} />}></Route>
                    <Route path="/register" component={()=><Login setFirstName={setFirstName} />}></Route>
                    
                </main>
            </BrowserRouter>


        </div>

    );
}

export default App;
