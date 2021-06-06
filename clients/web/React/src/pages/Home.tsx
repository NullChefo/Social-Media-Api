import React, {useState} from 'react';

const Home = (props: { firstName: string }) => {
    
    return (
       
        <div>  {props.firstName ? 'Hi ' + props.firstName : 'You are not logged in'} </div>

    )
};

export default Home;