import './App.css';
import {useState, useEffect} from 'react';
import projectService from '../Service/ProjectService';

function DeleteProject() {

    const [project, setProject] = useState({
        ProjectID: ""
    });

    const [submitted, setSubmit] = useState(false);

    const deleteProject = () => {
        projectService.DeleteProject(project.ProjectID)
          .then(response => {
            console.log(response.data);
        })
          .catch(e => {
            console.log(e);
        });

        setSubmit(true);
    };

    const handleInputChange = event => {
        const { name, value } = event.target;
        setProject({ ...project, [name]: value });
        console.log(project);
    };

    const newProject = () => {
        setSubmit(false);
    }

    return(
        <div className="App-header">
            {submitted ? (
                <div>
                    <p>Sucess!</p>
                    <button onClick={newProject}>Go again!</button>
                </div>
            ) : (
                <div>
                    <h4>What delete?</h4>
                    <form>
                        <input type="text" name="ProjectID" placeholder='ID to Delete' value={project.ProjectID} onChange={handleInputChange}></input><br/>
                        <input type="button" name="" value="Submit post reqeust" onClick = {deleteProject} onChange={handleInputChange}></input><br/>
                    </form>
                </div>
            )}         
        </div>
    )
}

export default DeleteProject;