import React, {SyntheticEvent, useState} from 'react';
import {Redirect} from 'react-router-dom';

const Register = (props: { setFirstName: (name: string)=> void }) => {
    
    const [userEmail, setUserEmail] = useState('');
    const [userPassword, setUserPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [middleName, setMiddleName] = useState('');
    const [lastName, setLastName] = useState('');
    const [location, setLocation] = useState('');
    const [website, setWebsite] = useState('');
    const [bio, setBio] = useState('');
    const [imageId, setImageId] = useState('');


    // #TODO upload picture


    const [redirect, setRedirect] = useState(false);

    const submit = async (e: SyntheticEvent) => {

        const response =
            await fetch('https://localhost:44321/api/User', {
                method: 'POST',
                headers: {'Access-Control-Allow-Credentials':'true','Content-Type': 'application/json' },
                body: JSON.stringify({
                    userEmail,
                    userPassword,
                    firstName,
                    middleName,
                    lastName,
                    imageId,
                    location,
                    website,
                    bio,
                })
            })

        const content = await response.json();
        
        console.log(content);


        setFirstName(firstName);
        setRedirect(true);

    };

    if (redirect) {
        return <Redirect to="/login"/>
    }


    return (
        <form onSubmit={submit}>
            <h1 className="h3 mb-3 fw-normal">Empty</h1>
            <h1 className="h3 mb-3 fw-normal">Please register</h1>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="name@example.com" onChange={e => setUserEmail(e.target.value)}/>
                <label htmlFor="floatingInput">Email address *</label>
            </div>

            <div className="form-floating">
                <input type="password" className="form-control"
                       placeholder="Password" onChange={e => setUserPassword(e.target.value)}/>
                <label htmlFor="floatingPassword">Password *</label>

            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="First Name" onChange={e => setFirstName(e.target.value)}/>
                <label htmlFor="floatingInput">First Name *</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Middle name" onChange={e => setMiddleName(e.target.value)}/>
                <label htmlFor="floatingInput">Middle Name</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Last name" onChange={e => setLastName(e.target.value)}/>
                <label htmlFor="floatingInput">Last Name *</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Location" onChange={e => setLocation(e.target.value)}/>
                <label htmlFor="floatingInput">Location</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Website" onChange={e => setWebsite(e.target.value)}/>
                <label htmlFor="floatingInput">Website</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Your Bio" onChange={e => setBio(e.target.value)}/>
                <label htmlFor="floatingInput">Biography</label>
            </div>

            <div className="form-floating">
                <input type="text" className="form-control"
                       placeholder="Your Image" onChange={e => setImageId(e.target.value)}/>
                <label htmlFor="floatingInput">Image</label>
            </div>


            <button className="w-100 btn btn-lg btn-primary" type="submit">Submit</button>

        </form>
    );
};

export default Register;