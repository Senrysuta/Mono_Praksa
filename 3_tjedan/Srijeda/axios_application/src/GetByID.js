
import React, { Component } from 'react'
import axios from 'axios';
import {useState} from 'react'

function GetByID() {
    const [author, setAuthor] = useState({});



    axios.get('https://localhost:44344/api/Author/2').then((response) => 
    {
        setAuthor(response.data)
    });


    return(
            <tr key={author.AuthorId}>
              <td>
                {author.AuthorId}
              </td>
              <td>
                {author.FirstName}
              </td>
              <td>
                {author.LastName}
              </td>
            </tr>
    );
}


export default GetByID;
