var appConfig={
    baseUrl: "http://localhost/Tickets.API/",
    views: "app/views/",
    controllers: {
        events:'Admin/',
        tickets: 'TicketsSell/',
        validation: "Validation"
    },
    models: {
        events: "Events",
        tickets: "Tickets",
        sessions: "Sessions",
        eventSessions: "EventSessions",
        sessionTickets: "SessionTickets",
        pagedEvents: "PagedEvents"
    },
    pageSize:10
};