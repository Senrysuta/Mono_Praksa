import {useState, useEffect} from 'react';
import projectService from '../Service/ProjectService';
import './App.css';


function GetProjectByID() {
    
    const [projects, setProjects] = useState({
        Location: {
            PostalCode: 32100,
            LocationName: "forkusevci"
        },
        State: {
            StateName: "Idea"
        },
        ProjectName: "building",
        Summary: "summary",
        Category: "building"

    });
    
    useEffect(() => {
        projectService.getById("D7B22584-7221-4FED-A2C4-2C1977854603")
        .then(response => {
          setProjects(response.data);
          console.log(response.data);
        })
    }, []);

    return(
        <table>
            <tr>
                <td>Project Name</td>
                <td>Summary</td>
                <td>Category</td>
                <td>Location Name</td>
                <td>Current State</td> 
            </tr>
            <tr>
                <td>{projects.ProjectName}</td>
                <td>{projects.Category}</td>
                <td>{projects.Location.PostalCode}</td>
                <td>{projects.Location.LocationName}</td>
                <td>{projects.State.StateName}</td>
            </tr>   
        </table>
        
    );
}


export default GetProjectByID;