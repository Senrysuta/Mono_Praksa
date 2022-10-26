import './App.css';
import GetAll from './GetAll';
import GetByID from './GetByID';

function GetGrid(params) {
    
    return(

    <div className="App">
        <header className="App-header">
            <p>Authors:</p><br/>
            <table>
                <tbody>
                    <tr>
                        <td>ID</td>
                        <td>First Name</td>
                        <td>Last Name</td>
                    </tr>
                </tbody><br/>
                    <GetAll/>
                    <br/><br/>
                    <GetByID />
            </table>
        </header>
    </div>
  );
}

export default GetGrid;