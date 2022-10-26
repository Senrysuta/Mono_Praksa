
import React, { Component } from 'react'
import axios from 'axios';

export default class GetAll extends Component {

    state = {
        author : []
      }
    
      componentWillMount()
      {
        axios.get('https://localhost:44344/api/Author').then((response) => 
        {
          this.setState(
            {
              author: response.data
            }
          )
        });
      }


  render() {
    return(
    this.state.author.map((author) =>
    {
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
      )
    })
    );
  }
}
