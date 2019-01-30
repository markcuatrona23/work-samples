import apiExecute from '../common/apiExecute';

const baseUrl = "/api/";

const viewAll = () => {
    return apiExecute(`${baseUrl}events/events`, "GET", null);
};

const viewAllEvents = () => {
    return apiExecute(`${baseUrl}events/events/all`, "GET", null);
};

const viewRelatedEventsByOrg = (id) => {
    return apiExecute(`${baseUrl}events/events/Related/${id}`, "GET", null);
};

const save = (model) => {
    return apiExecute(`${baseUrl}events/events/Save`, "POST", model);
};

const put = (model) => {
    return apiExecute(`${baseUrl}events/events/${model.id}`, "PUT", model);
};

const getId = (id) => {
    return apiExecute(`${baseUrl}events/events/${id}`, "GET", null);
};
const deleteEvent = (id) => {
    return apiExecute(`${baseUrl}events/events/${id}`, "DELETE", null);
};

const eventTypes = () => {
    return apiExecute(`${baseUrl}events/eventTypes`, "GET", null);
};
const states = () => {
    return apiExecute(`${baseUrl}common/USStates`, "GET", null);
};

const scholarship = () => {
    return apiExecute(`${baseUrl}organization/scholarships`, "GET", null);
};

const organization = () => {
    return apiExecute(`${baseUrl}organization/Organizations`, "GET", null);
};

const getOrgByUserBaseId = (userBaseId) => {
    return apiExecute(`${baseUrl}events/orgId/${userBaseId}`, "GET", null);
};

//for getall events 
const getAllEvents = () => {
    return apiExecute(`${baseUrl}events/events/selectall`, "GET", null);
}

export const EventsApi = {
    viewAll,
    viewAllEvents,
    eventTypes,
    states,
    getId,
    deleteEvent,
    save,
    put,
    scholarship,
    organization,
    viewRelatedEventsByOrg,
    getOrgByUserBaseId,
    getAllEvents
}