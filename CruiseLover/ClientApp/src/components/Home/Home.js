import React, { Component } from 'react';
import ImageFadeIn from "react-image-fade-in";
import './Home.css'

export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = { imageStatus: 'loading'};
    }

    handleImageLoaded() {
        this.setState({ imageStatus: "loaded" });
    }

    render() {
        return (
            <div className="homePage">
                <h1 className="homeTitle">Cruise Lovers</h1>
                <h1 className="homeDescription">THE BEST CRUISE DEALS & SPECIAL OFFERS</h1>
                <div className="flip-card-containers">
                    <div className="flip-card-container" style={{ display: this.state.imageStatus == "loaded" ? "inherit" : "none" }}>
                        <div className="flip-card">

                            <div className="card-front">
                                <figure>
                                    <div className="img-bg"></div>
                                    <ImageFadeIn src={"/images/card_1.jpg"} onLoad={this.handleImageLoaded.bind(this)} />
                                    <figcaption>Cruise Finder</figcaption>
                                </figure>
                            </div>

                            <div className="card-back">
                                <figure>
                                    <div className="img-bg"></div>
                                    <img src={"/images/card_1.jpg"} />
                                </figure>

                                <button onClick={() => { this.props.history.push('/cruiseDetails')}}>Book</button>
                            </div>

                        </div>
                    </div>

                    <div className="flip-card-container" style={{ display: this.state.imageStatus == "loaded" ? "inherit" : "none" }}>
                        <div className="flip-card">

                            <div className="card-front">
                                <figure>
                                    <div className="img-bg"></div>
                                    <ImageFadeIn src={"/images/card_2.jpg"} onLoad={this.handleImageLoaded.bind(this)} />
                                    <figcaption>Best Deals</figcaption>
                                </figure>
                            </div>

                            <div className="card-back">
                                <figure>
                                    <div className="img-bg"></div>
                                    <img src="/images/card_2.jpg" />
                                </figure>

                                <button onClick={() => { this.props.history.push('/deals') }}>Book</button>
                            </div>

                        </div>
                    </div>

                    <div className="flip-card-container" style={{ display: this.state.imageStatus == "loaded" ? "inherit" : "none" }}>
                        <div className="flip-card">

                            <div className="card-front">
                                <figure>
                                    <div className="img-bg"></div>
                                    <ImageFadeIn src={"/images/card_3.jpg"} onLoad={this.handleImageLoaded.bind(this)} />
                                    <figcaption>Choose your destination</figcaption>
                                </figure>
                            </div>

                            <div className="card-back">
                                <figure>
                                    <div className="img-bg"></div>
                                    <img src="/images/card_3.jpg" />
                                </figure>

                                <button onClick={() => { this.props.history.push('/destinations') }}>Select</button>
                            </div>

                        </div>
                    </div>

                    <div className="flip-card-container" style={{ display: this.state.imageStatus == "loaded" ? "inherit" : "none" }}>
                        <div className="flip-card">

                            <div className="card-front">
                                <figure>
                                    <div className="img-bg"></div>
                                    <ImageFadeIn src={"/images/card_4.jpg"} onLoad={this.handleImageLoaded.bind(this)} />
                                    <figcaption>Our Ships</figcaption>
                                </figure>
                            </div>

                            <div className="card-back">
                                <figure>
                                    <div className="img-bg"></div>
                                    <img src="/images/card_4.jpg" />
                                </figure>

                                <button onClick={() => { this.props.history.push('/ships') }}>Visit</button>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
