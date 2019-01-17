import * as React from 'react'
import { EventsApi } from './EventsApi';
import { IEventList } from './EventsForm';
import * as moment from 'moment'

export interface IRelatedDetailsState {
    relatedEvents: IEventList[]
}

interface IRelatedEventProps {
    organizationId: number
    eventId: any
}

class RelatedEvents extends React.Component<IRelatedEventProps, IRelatedDetailsState>{
    constructor(props) {
        super(props);
        this.state = {
            relatedEvents: []
        }
    }

    public componentWillReceiveProps(nextProps) {
        if (this.props.organizationId != nextProps.organizationId) {
            this.related(nextProps.eventId);
        }
    }

    related = (id) => {
        EventsApi.viewRelatedEventsByOrg(id)
            .then(response => {
                let items = response.items.sort(function (a, b) {
                    return Number(new Date(a.startDate)) - Number(new Date(b.startDate))
                })
                this.setState({
                    ...this.state,
                    relatedEvents: items
                })
            })
            .catch(error => console.log(error))
    }

    render() {
        return (
            <div style={{ maxHeight: 430, borderLeft: "1px solid #EDEDED", margin: '0 auto', overflowY: "scroll" }}>
                {this.state.relatedEvents.map(relatedEvents => {
                    return (
                        <a key={relatedEvents.id} className="img-thumbnail-zoom-in" href={`/user/social/events/${relatedEvents.id}`} >
                            <div className="card mb-4">
                                <div className="card-body">
                                    <div className="col-md-12" style={{ color: "black" }}>
                                        <div className="row">
                                            <div className="col-md-6">
                                                <h4 className="card-title">Event: {relatedEvents.title}</h4>
                                                <div className="card-subtitle text-muted mb-3">{relatedEvents.venueName}, {moment(relatedEvents.startDate).format('MM-DD-YYYY')}</div>
                                                <p className="card-text">{relatedEvents.topicDesc.length > 60 ? (relatedEvents.topicDesc).substr(0, 60) + "..." : (relatedEvents.topicDesc)}</p>
                                            </div>
                                            <div className="col-md-6 row justify-content-md-center">
                                                <img src={relatedEvents.imageUrl} alt="http://eleveight.co/wp-content/uploads/2016/07/eleveight-logo-navbar.png" style={{ width: "200px", height: "150px" }} />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </a>
                    )
                })}
            </div>
        )
    }
}

export default RelatedEvents;