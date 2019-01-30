import * as React from 'react';
import { IEventsForm, IEventList } from './EventsForm';
import * as moment from 'moment';
import { Card } from '../common/card'

interface IEventsPublicFormProps {
    allEventsList: IEventList[]
}

export const EventsPublicForm = (props: IEventsPublicFormProps) => (
    <div> <h2 className="card-header mb-4">Upcoming Events</h2>
        <div style={{ display: "grid", gridTemplateColumns: "30% 30% 30%", justifyContent: "space-evenly", alignItems: "stretch" }}>
            {props.allEventsList.map(events => {
                //type 2 is Public
                if (events.eventTypeId == 2) {
                    return (
                        <div className="form-row" key={events.id}>
                            <div className="card mb-4 col-md-12">
                                <a target="_blank" href={`/user/social/events/${events.id}`}>
                                    <img className="card-img-top" src={events.imageUrl} />
                                </a>
                                <div className="card-body">
                                    <h3 className="card-header text-center mb-4"><strong><span style={{ color: "gray" }}><i>{events.title}</i></span></strong> </h3>
                                    <p><strong>Description:</strong> {events.topicDesc.length > 150 ? (events.topicDesc).substr(0, 150) + "..." : (events.topicDesc)}</p>
                                    <p><strong>Start Date:</strong> {moment(events.startDate).format('MMM Do, YYYY')}</p>
                                    <p><strong>Start Time:</strong> {moment(events.startTime, 'HH:mm:ss').format('hh:mm A')}</p>
                                    <p><strong>Venue:</strong> {events.venueName}</p>
                                    <p><strong>Address: </strong>{events.streetAddress},</p>
                                    <p>{events.city}, {events.stateProvinceCode} {events.postalCode}</p>
                                </div>
                            </div>
                        </div>
                    )
                }
            }
            )
            }
        </div>
    </div>
)
