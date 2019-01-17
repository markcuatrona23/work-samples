import * as React from 'react';
import { EventsApi } from './EventsApi';
import { Card } from '../common/card';
import { IEventList } from './EventsForm';
import * as moment from 'moment';
import RelatedEvents from './RelatedEvents';
import { EventRSVP } from './EventRSVP';
import { RSVPApi } from './RSVPTypesApi';
import { ITextValue } from '../common/form/ITextValue';
import { EventRSVPApi } from './EventRSVPApi';

export interface IPeopleCount {
    eventId: number
    userBaseId: number,
    rsvpTypeId: number,
    peopleGoing: number,
    peopleInterested: number
}

export interface IEventDetails {
    details: IEventList,
    related: IEventList[],
    eventId: any,
    rsvpTypes: ITextValue[],
    payload: {
        eventId: any,
        userBaseId: number,
        rsvpTypeId: number
    }
    peopleCount: IPeopleCount
}

class EventDetails extends React.Component<any, IEventDetails>{
    constructor(props) {
        super(props);
        this.state = {
            details: {
                id: 0,
                organizationId: 0,
                eventTypeId: 0,
                title: "",
                topicDesc: "",
                startDate: "",
                startTime: "",
                endDate: "",
                endTime: "",
                isAllDay: "",
                venueName: "",
                streetAddress: "",
                city: "",
                stateProvinceId: 0,
                postalCode: "",
                stateProvinceCode: "",
                orgName: "",
                typeName: "",
                imageUrl: "",
                contactInfo: "",
                name: ""
            },
            peopleCount: {
                eventId: 0,
                userBaseId: 0,
                rsvpTypeId: 0,
                peopleGoing: 0,
                peopleInterested: 0
            },

            eventId: props.match.params.id,
            related: [],
            rsvpTypes: [{ value: "", text: "Please select one..." }],
            payload: {
                eventId: props.match.params.id,
                userBaseId: 0,
                rsvpTypeId: 0
            },
        }
    }

    onRSVPChange = () => {
        let obj = this.state.payload
        let item = this.state.payload.rsvpTypeId
        if (item == 1) {
            EventRSVPApi.postRSVP(this.state.payload)
                .then(response => {
                    this.getPeopleCount();
                })
                .catch(error => console.log("Error", error))
        }

        else if (item == 2) {
            EventRSVPApi.deleteRSVP(obj.eventId, obj.userBaseId)
                .then(response => {
                    this.getPeopleCount();
                })
                .catch(error => console.log(error))
        }

        else if (item == 3) {
            EventRSVPApi.updateRSVP(this.state.payload)
                .then(response => {
                    this.getPeopleCount();
                })
                .catch(error => console.log(error))
        }
    }

    onChange = (fieldName, fieldValue) => {
        let nextState = {
            payload: {
                ...this.state.payload,
                [fieldName]: fieldValue
            }
        };
        this.setState(nextState);
    }

    public componentDidMount() {
        this.getEvent();
        this.relatedEvents();
        this.rsvpDropdown();
        this.getPeopleCount();
    }

    getPeopleCount = () => {
        EventRSVPApi.getPeopleCount(this.state.eventId)
            .then(response => {
                this.setState({
                    ...this.state,
                    peopleCount: response.item
                })
            })
            .catch(error => console.log("error", error))
    }

    rsvpDropdown = () => {
        RSVPApi.getAllRSVPTypes()
            .then(response => {
                let obj = this.state.rsvpTypes.concat(response.items.map(list => {
                    return { value: list.id, text: list.rsvpType }
                }))
                this.setState({
                    rsvpTypes: obj
                })
            })
            .catch(error => console.log("ERROR", error));
    }

    getEvent = () => {
        EventsApi.getId(this.state.eventId)
            .then(response => {
                this.setState({
                    ...this.state,
                    details: response.item
                })
            })
            .catch(error => console.log(error))
    }

    relatedEvents = () => {
        EventsApi.viewAll()
            .then(response => {
                let obj = response.items.sort(function (a, b) {
                    return a.id - b.id;
                });
                this.setState({
                    ...this.state,
                    related: obj
                })
            })
            .catch(error => console.log(error))
    }

    render() {
        return (
            <div className="container-fluid">

                <div>
                    <div className="card-header" style={{ display: "grid", gridTemplateColumns: "50% 50%", justifyContent: "space-evenly" }} >
                        <div style={{ placeSelf: "center" }}>
                            <img className="col-md-12" src={this.state.details.imageUrl} alt="http://eleveight.co/wp-content/uploads/2016/07/eleveight-logo-navbar.png" />
                        </div>
                        <div style={{ placeSelf: "center" }}>
                            <div><span style={{ fontSize: "32px" }}><strong><span style={{ color: "gray" }}>{this.state.details.title}</span></strong></span></div>
                            <div style={{ fontSize: "22px" }}><b>Hosted by</b> - {this.state.details.orgName}</div>
                            <div style={{ fontSize: "18px" }}>{this.state.details.name}</div>
                            {this.state.peopleCount.peopleGoing > 1 ? (
                                <div> {this.state.peopleCount.peopleGoing} people are going.</div>
                            ) : (
                                    this.state.peopleCount.peopleGoing === 1 ? (
                                        <div>{this.state.peopleCount.peopleGoing} person is going.</div>
                                    ) : (""))
                            }

                            {this.state.peopleCount.peopleInterested > 1 ? (
                                <div> {this.state.peopleCount.peopleInterested} people are interested in going.</div>
                            ) : (
                                    this.state.peopleCount.peopleInterested === 1 ? (
                                        <div>{this.state.peopleCount.peopleInterested} person is interested in going.</div>
                                    ) : (""))
                            }
                        </div>
                    </div>
                    <div className="card-body">
                        <div className="row">
                            <div className="col-md-6">
                                <Card>
                                    <div className="mb-4">
                                        <div><h5><span>What's happening:</span></h5></div>
                                        <div><p>{this.state.details.topicDesc}</p></div>
                                    </div>
                                    <div className="mb-4">
                                        <div><h5><span>Event type:</span></h5></div>
                                        <div><p>{this.state.details.typeName}</p></div>
                                    </div>
                                    <div className="mb-4">
                                        <div><h5><span>Venue:</span> </h5></div>
                                        <div><p>{this.state.details.venueName}, {this.state.details.streetAddress}, {this.state.details.city}, {this.state.details.stateProvinceCode} {this.state.details.postalCode}</p></div>
                                    </div>
                                    <div className="mb-4">
                                        <div><h5><span>When:</span></h5></div>
                                        <div><p>{moment(this.state.details.startDate).format('MMMM Do, YYYY')}, {moment(this.state.details.startTime, 'HH:mm:ss').format('h:mm a')} </p></div>
                                    </div>
                                    <div className="mb-4">
                                        <div><h5><span>All day Event?</span></h5></div>
                                        <div><p>{this.state.details.isAllDay ? "Yes" : "No"}</p></div>
                                    </div>
                                    <div className="mb-4">
                                        <div>
                                            <h5><span>Contact Info:</span></h5>
                                        </div>
                                        <div>
                                            <p>{this.state.details.contactInfo}</p>
                                        </div>

                                    </div>
                                </Card>
                            </div>

                            <div className="col-md-6" style={{ display: "grid", justifyContent: "space-evenly" }}>
                                <div className="card mb-4">
                                    <div className="card-body">
                                        <EventRSVP
                                            options={this.state.rsvpTypes}
                                            onChange={this.onChange}
                                            payload={this.state.payload}
                                            onSubmitRSVP={this.onRSVPChange}
                                        /></div>
                                </div>
                                <p className="mb-4" style={{ textAlign: "center" }}> For directions, click on the Google Maps photo.</p>
                                <div className="row justify-content-md-center mb-4">
                                    <a target="_blank" className="img-thumbnail-zoom-in" href={`https://www.google.com/maps/place/${this.state.details.streetAddress},+${this.state.details.city},+${this.state.details.stateProvinceCode}+${this.state.details.stateProvinceCode}/`}>
                                        <img src={`https://maps.googleapis.com/maps/api/staticmap?center=${this.state.details.streetAddress},+${this.state.details.city},+${this.state.details.stateProvinceCode}+${this.state.details.stateProvinceCode}&zoom=13&scale=1&size=600x300&maptype=hybrid&key=AIzaSyCQHurErpXDh3Y89jvtzzv_O_3tYyoeptI&format=png&visual_refresh=true&markers=size:mid%7Ccolor:0xff0000%7Clabel:%7C${this.state.details.streetAddress},+${this.state.details.city},+${this.state.details.stateProvinceCode}+${this.state.details.stateProvinceCode}`} alt={`Google Map of ${this.state.details.streetAddress}, ${this.state.details.city}, ${this.state.details.stateProvinceCode} ${this.state.details.stateProvinceCode}`} /></a>
                                </div>
                                <div className="mb-4">
                                    <h5 style={{ textAlign: "center" }}>Upcoming events from {this.state.details.orgName}:</h5>
                                    <RelatedEvents
                                        organizationId={this.state.details.organizationId}
                                        eventId={this.state.eventId}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
export default EventDetails;