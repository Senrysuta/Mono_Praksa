import './App.css';
import FindProjects from './FindProjects';
import GetAll from './GetAllProjects';
import GetByID from './GetProjectByID';
import PostProject from './PostProject';
import DeleteProject from './DeleteProject';
import UpdateProject from './UpdateProject';

function GetGrid(params) {
    
    return(

    <div className="App">
        <header className="App-header">
            <p>Projects:</p><br/>
            <GetAll />

            <br/>
            <p>Project by Id: D7B22584-7221-4FED-A2C4-2C1977854603</p>

            <GetByID />

            <br/>
            <br/>
            <p>Find Projects: </p>
            <FindProjects />
            <DeleteProject />            
            
        </header>
            <UpdateProject />
            <PostProject />

    </div>
  );
}

export default GetGrid;