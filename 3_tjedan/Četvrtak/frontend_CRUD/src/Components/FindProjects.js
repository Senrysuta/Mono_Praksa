import {useState, useEffect} from 'react';
import projectService from '../Service/ProjectService';
import './App.css'



function FindProjects() {
    
    const [projects, setProjects] = useState([]);

    useEffect(() => {
        projectService.Find("10","1","ProjectName","ASC","","")
        .then(response => {
          setProjects(response.data);
          console.log(response.data);
        })
    }, []);


    const projectData = projects.map((data) => {
        return(
            <tr>
                <td>{data.ProjectName}</td>
                <td>{data.Summary}</td>
                <td>{data.Category}</td>
                <td>{data.Location.LocationName}</td>
                <td>{data.State.StateName}</td>
            </tr>
        )
    })

    return(
        <table>
            <tr>
                <td>Project Name</td>
                <td>Summary</td>
                <td>Category</td>
                <td>Location Name</td>
                <td>Current State</td> 
            </tr>
            <br/>
            {projectData}    
        </table>
        
    );

}


export default FindProjects;