import apiExecute from '../common/apiExecute';

const baseUrl = "/api/events/";

const getAllRSVP = () => {
    return apiExecute(`${baseUrl}eventRSVPs`, "GET", null);
}

const postRSVP = (data) => {
    return apiExecute(`${baseUrl}eventRSVPs`, "POST", data);
}

const updateRSVP = (data) => {
    return apiExecute(`${baseUrl}eventRSVPs/${data.eventId}/${data.userBaseId}`, "PUT", data);
}

const deleteRSVP = (idOne, idTwo) => {
    return apiExecute(`${baseUrl}eventRSVPs/${idOne}/${idTwo}`, "DELETE", null);
}

const getPeopleCount = (id) => {
    return apiExecute(`${baseUrl}eventRSVPs/${id}`, "GET", null);
}

export const EventRSVPApi = {
    getAllRSVP,
    postRSVP,
    updateRSVP,
    deleteRSVP,
    getPeopleCount
}