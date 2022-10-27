import {useState, useEffect} from 'react';
import projectService from '../Service/ProjectService';
import axios from 'axios';
import './App.css'



function PostProject() {

    const [project, setProject] = useState({
        Location: {
            PostalCode: "10370"
        },
        State: {
            StateId: "1"
        },
        ProjectName: "",
        Summary: "",
        Category: "",
        IsActive: true
    });

    const [submitted, setSubmit] = useState(false);
    
    const handleInputChange = event => {
        const { name, value } = event.target;
        setProject({ ...project, [name]: value });
        console.log(project);
    };
    
    const saveProject = () => {
        var data = {
            Location: {
                PostalCode: project.Location.PostalCode
            },
            State: {
                StateId: project.State.StateId
            }, 
            ProjectName: project.ProjectName,
            Summary: project.Summary,
            Category: project.Category,
            IsActive: true
        };

        axios.post("https://localhost:44362/api/Project/PostProject", data).then(res => {
        setProject(JSON.stringify(res.data));
        console.log(res.data);
        })
        .catch(e => {
        console.log(e);
        });

        setSubmit(true);

    };  

    const newProject = ()=>{
        setProject({
            Location: {
                PostalCode: "10370"
            },
            State: {
                StateId: "1"
            },
            ProjectName: "",
            Summary: "",
            Category: "",
            IsActive: true
        });
        setSubmit(false);
    };

    return(
        <div className="App-header">
            {submitted ? (
                <div>
                    <p>Sucess!</p>
                    <button onClick={newProject}>Go again!</button>
                </div>
            ) : (
                <div>
                    <h4>Fullfill the From to Add a new project: </h4>
                    <form>
                        <input type="number" name="Location" placeholder='Postal Code' value={project.Location.PostalCode} onChange={handleInputChange}></input><br/>
                        <input type="number" name="State" placeholder='State' value={project.State.StateId} onChange={handleInputChange}></input><br/>
                        <input type="text" name="ProjectName" placeholder='Project Name' value={project.ProjectName} onChange={handleInputChange}></input><br/>
                        <input type="text" name="Summary" placeholder='Project Summary' value={project.Summary} onChange={handleInputChange}></input><br/>
                        <input type="text" name="Category" placeholder='Project Category' value={project.Category} onChange={handleInputChange}></input><br/>
                        <input type="button" name="" value="Submit post reqeust" onClick = {saveProject}></input><br/>
                    </form>
                </div>
            )}         
        </div>
    )


}


export default PostProject;