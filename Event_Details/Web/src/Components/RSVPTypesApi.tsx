import apiExecute from '../common/apiExecute';

const baseUrl = "/api/events/";

const getAllRSVPTypes = () => {
    return apiExecute(`${baseUrl}rsvptypes`, "GET", null);
};

const getRSVPById = (id) => {
    return apiExecute(`${baseUrl}rsvptypes/${id}`, "GET", null);
};

const postRSVP = (data) => {
    return apiExecute(`${baseUrl}rsvptypes`, "POST", data);
};

const updateRSVP = (data) => {
    return apiExecute(`${baseUrl}rsvptypes/${data.id}`, "PUT", data);
};

const deleteRSVP = (id) => {
    return apiExecute(`${baseUrl}rsvptypes/${id}`, "DELETE", null);
};

export const RSVPApi = {
    getAllRSVPTypes,
    getRSVPById,
    postRSVP,
    updateRSVP,
    deleteRSVP
}