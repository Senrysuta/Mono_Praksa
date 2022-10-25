import React, { Component } from 'react'
import {useState} from "react"
import Save from './SaveValue';

function Form(props) {
    const [name, setName] = useState("");

    const handleSubmit = (event) =>
    {
        event.preventDefault();
        alert(`Your Name: ${name}`);
    }

    const transferValue = (event) => {
        event.preventDefault();
        const val = {
          name,
        };
        props.func(val);
        clearState();
    };

    const clearState = () => {
        setName('');
      };

    return (
      <div className='form'>
        <form>
            <label for="firstName">Your Name:  </label>
            <input type="text" value={name} id="firstName" onChange={(e) => setName(e.target.value)} placeholder="Insert your name here"></input><br />
            <input type="button" value={"Submit your answear"} onClick={transferValue} placeholder="Submit your name"></input>
        </form>
      </div>
    )
}

export default Form; 
