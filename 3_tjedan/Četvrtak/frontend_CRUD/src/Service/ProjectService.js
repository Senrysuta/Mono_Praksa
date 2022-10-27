import http from "../http-common";

const getAll = () => {
    return http.get("/Project/GetAllProjects");
};

 

const getById = id => {
    return http.get(`/Project/GetProject/${id}`);
};


const Find = (Rpp = null, pageNumber = null, OrderBy = null, sortOrder = null, projectName = null, locationName = null) => {
    let params = {Rpp, pageNumber, OrderBy, sortOrder, projectName, locationName}
    return http.get(`/Project/GetAllProjects`,{params});
};

const PostProject = data => {
    return http.post(`/Project/PostProject/`,data);
}

const DeleteProject = id => {
    return http.delete(`/Project/DeleteProject/${id}`);
};

const Update = (id, data) => {
    return http.put(`/Project/UpdateProject/${id}`, data);
};



const projectService = {
    getAll,
    getById,
    Find,
    PostProject,
    DeleteProject,
    Update
};
  
export default projectService;  