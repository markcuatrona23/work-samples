import * as React from 'react';
import { IEventsForm, EventsForm, IEventList } from './EventsForm';
import { EventsApi } from './EventsApi';
import { Card } from '../common/card';
import { Button } from '../common/form';
import { ITextValue } from '../common/form/ITextValue';
import { validateFields, formatTestCase, ITestCase } from "../common/DynamicRuleValidation";
import * as moment from 'moment';
import ReactCrop, { makeAspectCrop } from 'react-image-crop';
import 'react-image-crop/dist/ReactCrop.css';
import apiExecute from '../common/apiExecute';
//import { EventsPublicForm } from './EventsPublicForm';
import * as toastr from 'toastr';

export interface IEventsPage {
    eventsObj: IEventsForm,
    eventTypeList: ITextValue[],
    eventList: IEventList[],
    stateList: ITextValue[],
    scholarshipList: ITextValue[],
    organizationList: ITextValue[],
    deleteItem: number,
    isFormValid: boolean,
    error: any,
    errorMessage?: string,
    userBaseId: number,
    orgId: number,

}

class EventsPage extends React.Component<any, IEventsPage>{
    constructor(props) {
        super(props);
        this.state = {
            eventsObj: {
                id: 0,
                organizationId: 0,
                eventTypeId: 0,
                title: "",
                topicDesc: "",
                startDate: "",
                startTime: "",
                endDate: "",
                endTime: "",
                isAllDay: false,
                venueName: "",
                addressId: 0,
                streetAddress: "",
                city: "",
                stateProvinceId: 0,
                postalCode: "",
                scholarshipId: 0,
                imageUrl: "",
                contactInfo: "",
                modifiedById: 0,
                createdById: 0
            },
            eventTypeList: [{ value: "", text: "Please select Event Type..." }],
            stateList: [{ value: "", text: "Please select a State..." }],
            scholarshipList: [{ value: "", text: "Please select a Scholarship..." }],
            organizationList: [{ value: "", text: "Please select an Organization..." }],
            eventList: [],
            deleteItem: 0,
            isFormValid: false,
            error: {
                organizationId: "",
                eventTypeId: "",
                title: "",
                topicDesc: "",
                startDate: "",
                startTime: "",
                venueName: "",
                streetAddress: "",
                city: "",
                stateProvinceId: "",
                postalCode: "",
                scholarshipId: "",
                imageUrl: "",
                contactInfo: ""
            },
            userBaseId: 0,
            orgId: 0

        }
    }

    public componentDidMount() {
        this.viewAllEvents();
        this.eventTypes();
        this.states();
        this.scholarships();
        this.organizations();
        this.getOrgByUserBaseId();


    }


    onUploadComplete = (url) => {
        let nextState = {
            eventsObj: {
                ...this.state.eventsObj,
                imageUrl: url
            }
        }
        this.setState(nextState, () => { this.validateFields(this.state.eventsObj, "imageUrl") })
    }

    onChange = (fieldName: string, fieldValue: string) => {
        let nextState = {
            ...this.state,
            eventsObj: {
                ...this.state.eventsObj,
                [fieldName]: fieldValue
            }
        };
        this.setState(nextState, () => { this.validateFields(this.state.eventsObj, fieldName) });
    }

    postEvent = () => {
        if (!this.state.eventsObj.id)
            EventsApi.save(this.state.eventsObj)
                .then(response => {
                    this.viewAllEvents();
                    this.clear();
                    toastr.success("Event added.")

                })
                .catch(error => {
                    toastr.error("There's an error creating this event.")
                    console.log(error)
                });
        else {
            EventsApi.put(this.state.eventsObj)
                .then(response => {
                    this.viewAllEvents();
                    this.clear();
                    toastr.info("Event Updated.")
                })
                .catch(error => {
                    toastr.error("There's an error updating this event.")
                    console.log(error)
                })
        }
    }

    viewAllEvents = () => {
        EventsApi.viewAll()
            .then(response => {
                let items = response.items.sort(function (a, b) {
                    return Number(new Date(a.startDate)) - Number(new Date(b.startDate))
                })
                this.setState({
                    eventList: items
                })
            })
            .catch(error => console.log("ERROR", error));
    }

    eventTypes = () => {
        EventsApi.eventTypes()
            .then(response => {
                let obj = this.state.eventTypeList.concat(response.items.map(list => {
                    return { value: list.id, text: list.typeName }
                }));
                this.setState({
                    eventTypeList: obj
                });
            })
            .catch(error => console.log("ERROR", error));
    }

    states = () => {
        EventsApi.states()
            .then(response => {
                let item = this.state.stateList.concat(response.items.map(state => {
                    return { value: state.id, text: state.name }
                }));
                this.setState({
                    stateList: item
                });
            })
            .catch(error => console.log("ERROR", error));
    }

    scholarships = () => {
        EventsApi.scholarship()
            .then(response => {
                let item2 = this.state.scholarshipList.concat(response.items.map(scholar => {
                    return { value: scholar.id, text: scholar.name }
                }));
                this.setState({
                    scholarshipList: item2
                });
            })
            .catch(error => console.log("ERROR", error));
    }

    organizations = () => {
        EventsApi.organization()
            .then(response => {
                let item3 = this.state.organizationList.concat(response.items.map(org => {
                    return { value: org.id, text: org.orgName }
                }));
                this.setState({
                    organizationList: item3
                });
            })
            .catch(error => console.log("ERROR", error));
    }

    editButton = (id) => {
        EventsApi.getId(id)
            .then(response => {
                let selectedEvent = response.item;
                selectedEvent.startDate = moment(selectedEvent.startDate).format('YYYY-MM-DD');
                selectedEvent.endDate = moment(selectedEvent.endDate).format('YYYY-MM-DD');
                this.setState({
                    ...this.state,
                    eventsObj: selectedEvent
                });
            })
            .catch(error => console.log(error));
    }

    deleteButton = () => {
        EventsApi.deleteEvent(this.state.deleteItem)
            .then(response => {
                this.setState({
                    ...this.state,
                    deleteItem: 0
                })
                this.viewAllEvents();
            })
            .catch(error => console.log(error));
    }

    clear = () => {
        this.setState({
            eventsObj: {
                id: 0,
                organizationId: this.state.orgId,
                eventTypeId: 0,
                title: "",
                topicDesc: "",
                startDate: "",
                startTime: "",
                endDate: "",
                endTime: "",
                isAllDay: false,
                venueName: "",
                addressId: 0,
                streetAddress: "",
                city: "",
                stateProvinceId: 0,
                postalCode: "",
                scholarshipId: 0,
                imageUrl: "",
                contactInfo: "",
                modifiedById: 0,
                createdById: 0
            },
            deleteItem: 0,
            isFormValid: false
        },
            () => {
                if (document.getElementById("uploadComplete")) document.getElementById("uploadComplete").innerHTML = "";

            }
        )
    }

    clearDeleteId = () => {
        this.setState({
            deleteItem: 0
        })
    }

    validateFields = (form: any, fieldName: string) => {
        let tests: ITestCase[] = new Array<ITestCase>();
        for (let field in form) {
            let rules = {};
            switch (field) {

                case "scholarshipId":
                    rules = {
                        validDropDown: true
                    }
                    break;
                case "eventTypeId":
                    rules = {
                        validDropDown: true
                    }
                    break;
                case "title":
                    rules = {
                        minLength: 3,
                        maxLength: 100
                    }
                    break;
                case "topicDesc":
                    rules = {
                        minLength: 10,
                        maxLength: 2000
                    }
                    break;
                case "startDate":
                    rules = {
                        validDate: true
                    }
                    break;
                case "startTime":
                    rules = {
                        validTime: true
                    }
                    break;
                case "venueName":
                    rules = {
                        minLength: 3,
                        maxLength: 100
                    }
                    break;
                case "streetAddress":
                    rules = {
                        minLength: 3,
                        maxLength: 150
                    }
                    break;
                case "city":
                    rules = {
                        minLength: 3,
                        maxLength: 150
                    }
                    break;
                case "stateProvinceId":
                    rules = {
                        validDropDown: true
                    }
                    break;
                case "postalCode":
                    rules = {
                        minLength: 4,
                        maxLength: 10,
                        isNumber: true
                    }
                    break;
                case "contactInfo":
                    rules = {
                        minLength: 8,
                        maxLegnth: 200
                    }
                    break;
                case "imageUrl":
                    rules = {
                        universal: true
                    }
                default:
                    break;
            }
            tests.push(formatTestCase(form[field], field, rules, new Array<string>()))
        }
        tests = validateFields(tests);

        let newErrMsgs = { ...this.state.error };
        let currentFieldTest = tests.find(test => test.field == fieldName);
        if (currentFieldTest.errMsg.length > 0 && currentFieldTest.value)
            newErrMsgs = { ...this.state.error, [fieldName]: currentFieldTest.errMsg[0] };
        else newErrMsgs = { ...this.state.error, [fieldName]: "" }
        this.setState({ ...this.state, isFormValid: tests.every(test => test.errMsg.length == 0), error: newErrMsgs })
    }

    getOrgByUserBaseId = () => {
        EventsApi.getOrgByUserBaseId(this.state.userBaseId)
            .then(response => {
                let item = response.item.organizationId
                this.setState({
                    orgId: item
                })
            })
            .catch(error => console.log(error))
    }

    render() {
        return (
            <div>
                <div>
                    <div className="card-header mb-4">
                        <button
                            className="btn btn-primary waves-effect float-right"
                            data-toggle="modal"
                            data-target="#eventForm"
                            onClick={this.clear}
                        >Create</button>
                        <h2>Manage Events</h2>

                    </div>
                    <div style={{ display: "grid", gridTemplateColumns: "30% 30% 30%", justifyContent: "space-evenly" }}>
                        {this.state.eventList.map(events => {
                            return (
                                <div className="form-row" key={events.id} >
                                    <div className="card mb-4 col-md-12">
                                        <a target="_blank" href={`/user/social/events/${events.id}`}>
                                            <img className="card-img-top" src={events.imageUrl} />
                                        </a>
                                        <div className="card-body">
                                            <h3 className="card-header text-center mb-4"><i><b><span style={{ color: "gray" }}> {events.title}</span></b></i></h3>
                                            <p><strong>Description:</strong> {events.topicDesc.length > 150 ? (events.topicDesc).substr(0, 150) + "..." : (events.topicDesc)}</p>
                                            <p><strong>Start Date:</strong> {moment(events.startDate).format('MMM Do, YYYY')}</p>
                                            <p><strong>Start Time:</strong> {moment(events.startTime, 'HH:mm:ss').format('hh:mm A')}</p>
                                            <p><strong>Venue:</strong> {events.venueName}</p>
                                            <p><strong>Address:</strong> {events.streetAddress},</p>
                                            <p>{events.city}, {events.stateProvinceCode} {events.postalCode}</p>
                                            <div className="card-footer">
                                                <button
                                                    className="btn btn-sm waves-effect btn-primary"
                                                    onClick={() => this.editButton(events.id)}
                                                    data-toggle="modal"
                                                    data-target="#eventForm"
                                                >Edit</button>
                                                <button
                                                    className="btn btn-sm waves-effect btn-danger float-right"
                                                    onClick={() => this.setState({
                                                        ...this.state,
                                                        deleteItem: events.id
                                                    })}
                                                    data-toggle="modal"
                                                    data-target="#confirmDelete"
                                                >Delete</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                </div>
                <div>
                    <div className="modal fade" id="eventForm" style={{ display: "none", ariaHidden: "true" }}>
                        <div className="modal-dialog modal-lg">
                            <div className="modal-content">
                                <EventsForm
                                    events={this.state.eventsObj}
                                    onChange={this.onChange}
                                    eventTypeList={this.state.eventTypeList}
                                    states={this.state.stateList}
                                    scholarships={this.state.scholarshipList}
                                    organizations={this.state.organizationList}
                                    onUploadComplete={this.onUploadComplete}
                                    error={this.state.error}
                                    errorMessage={this.state.errorMessage}
                                    canvasUrl={this.state.eventsObj.imageUrl}
                                />
                                <div className="card-footer p-4">
                                    <button
                                        disabled={!this.state.isFormValid}
                                        className="btn btn-primary waves-effect"
                                        onClick={this.postEvent}
                                        data-dismiss="modal"
                                    >Submit</button>
                                    <button type="button" className="btn btn-default waves-effect float-right" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div className="modal fade" id="confirmDelete" style={{ display: "none", ariaHidden: "true" }}>
                            <div className="modal-dialog modal-md">
                                <div className="modal-content">
                                    <div className="container">
                                        <div className="card-body">
                                            <div className="col-md-12">
                                                <div className="row">
                                                    <div className="col-md-7">
                                                        <h4>Delete selected item?</h4>
                                                    </div>
                                                    <div className="col-md-5">
                                                        <button className="btn btn-default float-right" data-dismiss="modal" onClick={this.clearDeleteId}>Close</button>
                                                        <button className="btn btn-danger float-right" data-dismiss="modal" onClick={this.deleteButton}>Delete</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default EventsPage