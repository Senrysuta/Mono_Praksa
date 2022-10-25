import jsonData from './data.json'
import React, { useState }  from 'react'
import Form from './Form.js'



function Listing() {

    const [nameData, setNameData] = useState(jsonData);

    const listRows = nameData.map((info) =>
    {
        return(
            <li>{info.name}</li>
        );

    });

    const addRows = (data) => {
        const totalNames = nameData.length;
        data.id = totalNames + 1;
        const updatedNameData = [...nameData];
        updatedNameData.push(data);
        setNameData(updatedNameData);
        jsonData.map((data.id,updatedNameData))
        {
            return(
                {
                    "Id" : data.id,
                    "Name" : updatedNameData
                }
            );
        }
    }

    return (
        <div>
            <Form func={addRows} />
            <ul>{listRows}</ul>
        </div>
    );
    
}

export default Listing